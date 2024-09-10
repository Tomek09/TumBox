using System.Collections.Generic;
using System.Linq;
using TumBox.Extensions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TumBox.Tools
{
	public class SceneChanger : EditorWindowUtility
	{
		private class SceneData
		{
			public string name;
			public string path;
			public string guid;
			public int buildIndex;
		}

		private const float SCENE_HEIGHT = 30f;

		private List<SceneData> _scenesData;
		private int _totalScenes;
		private Vector2 _scenesScrollView;

		[MenuItem("TumBox/Scene Changer")]
		public static void ShowWindow()
		{
			SceneChanger editor = (SceneChanger)EditorWindow.GetWindow(typeof(SceneChanger));
			editor.titleContent = new GUIContent("Scene Changer");
			editor.SetupSceneData();
		}

		private void OnEnable()
		{
			SetupSceneData();
		}

		private void OnGUI()
		{
			DrawTools();
			DrawScenes();
		}

		private void SetupSceneData()
		{
			string[] guids = AssetDatabase.FindAssets("t: Scene");
			_scenesData = new();

			for (int i = 0; i < guids.Length; i++)
			{
				string path = AssetDatabase.GUIDToAssetPath(guids[i]);
				if (!path.StartsWith("Assets"))
					continue;

				SceneAsset asset = AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)) as SceneAsset;
				string name = asset.name;

				SceneData sceneData = new SceneData()
				{
					path = path,
					name = name,
					guid = guids[i],
					buildIndex = GetBuildIndex(path)
				};

				_scenesData.Add(sceneData);
			}
			_totalScenes = _scenesData.Count;
		}

		private int GetBuildIndex(string path)
		{
			EditorBuildSettingsScene[] settings = EditorBuildSettings.scenes;
			int totalSettings = settings.Length;
			for (int i = 0; i < totalSettings; i++)
			{
				if (string.Equals(path, settings[i].path))
				{
					return i;
				}
			}

			return -1;
		}

		private void DrawTools()
		{
			EditorExtensions.Horizontal(() =>
			{
				IconLabel(IconExtensions.Logo(), EditorStyles.label, 12, GUILayout.Width(30), GUILayout.Height(30));
				SmallButtonIcon("d_RotateTool@2x", "Refresh", OnRefreshScenes);
			}, "box", false, GUILayout.ExpandWidth(true), GUILayout.Height(30));
		}

		private void DrawScenes()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			_scenesScrollView = GUILayout.BeginScrollView(_scenesScrollView);
			for (int i = 0; i < _totalScenes; i++)
			{
				DrawScene(_scenesData[i]);
			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
		}

		private void DrawScene(SceneData scene)
		{
			bool buildNotIncluded = Equals(scene.buildIndex, -1);

			EditorExtensions.Horizontal(() => {
				EditorExtensions.Vertical(() => {
					Label(scene.name, EditorStyles.boldLabel, 15);
					Label(scene.path, EditorStyles.label, 10);
					Label(string.Format("Build included: {0}", buildNotIncluded ? "False" : "True"), EditorStyles.label, 8);
				}, GUIStyle.none, false, GUILayout.Width(100));

				GUILayout.FlexibleSpace();

				EditorExtensions.Vertical(() => {
					EditorExtensions.Horizontal(() => {
						SmallButtonIcon("d_Spotlight Icon", "Find scene asset", () => OnPingScene(scene.path));
						SmallButtonIcon(buildNotIncluded ? "d_Invalid@2x" : "d_GreenCheckmark@2x", "Build included", () => OnModifyBuild(scene.path, buildNotIncluded));
						SmallButtonIcon(IconExtensions.Home("", "Open scene"), () => OnChangeScene(scene.path));
					}, GUIStyle.none, false, GUILayout.ExpandWidth(true));
				}, GUIStyle.none, false);

			}, "Box", false, GUILayout.Height(SCENE_HEIGHT));
		}

		private void OnRefreshScenes()
		{
			SetupSceneData();
		}


		private void OnPingScene(string path)
		{
			var scene = AssetDatabase.LoadMainAssetAtPath(path);
			EditorGUIUtility.PingObject(scene);
		}

		private void OnModifyBuild(string path, bool isNotIncluded)
		{
			List<EditorBuildSettingsScene> settings = EditorBuildSettings.scenes.ToList();
			int total = settings.Count;
			if (isNotIncluded)
			{
				settings.Add(new EditorBuildSettingsScene(path, true));
			}
			else
			{
				for (int i = 0; i < total; i++)
				{
					if (string.Equals(settings[i].path, path))
					{
						settings.RemoveAt(i);
						break;
					}
				}
			}

			EditorBuildSettings.scenes = settings.ToArray();
			SetupSceneData();
		}

		private void OnChangeScene(string path)
		{
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
			{
				EditorSceneManager.OpenScene(path);
			}
		}
	}
}
