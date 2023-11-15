using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TumBox.Tools {
	public class SceneChanger : EditorWindow {

		#region Classes
		private class SceneData {
			public string Name;
			public string Path;
		}
		#endregion

		#region GUI
		private const float HeaderHeight = 50f;
		private const float NavigationHeight = 20f;
		private const float SceneHeight = 30f;

		private const float ButtonWidth = 100f;
		private const float ButtonHeight = 20f;
		#endregion

		#region Styles
		private GUIStyle _headerStyle;
		private GUIStyle _sceneNameStyle;
		private GUIStyle _scenePathStyle;
		#endregion

		#region Scenes
		private SceneData[] _sceneDatas;
		private int _totalScenes;
		private Vector2 _scenesScroll;
		#endregion

		[MenuItem("TumBox/Scene Changer")]
		public static void ShowWindow() {
			SceneChanger editor = (SceneChanger)GetWindow(typeof(SceneChanger));
			editor.titleContent = Extensions.IconExtensions.GetLogo("Scene Changer");
		}

		private void OnEnable() {
			FillStyles();
			FillSceneData();
		}

		private void OnGUI() {
			DrawHeader();
			DrawNavigation();
			DrawScenes();
		}


		private void DrawHeader() {
			Extensions.EditorExtensions.Horizontal(() => {
				GUILayout.FlexibleSpace();
				GUILayout.Label(Extensions.IconExtensions.GetLogo("Scene Changer"), _headerStyle, GUILayout.Height(HeaderHeight));
				GUILayout.FlexibleSpace();
			}, "Box");
		}

		private void DrawNavigation() {
			Extensions.EditorExtensions.Horizontal(() => {
				GUILayout.FlexibleSpace();
				DrawButton("Refresh", FillSceneData);
				GUILayout.FlexibleSpace();
			}, "Box", GUILayout.ExpandWidth(true), GUILayout.Height(NavigationHeight));
		}


		private void DrawScenes() {
			Extensions.EditorExtensions.VerticalScrollView(() => {
				for (int i = 0; i < _totalScenes; i++) {
					DrawScene(_sceneDatas[i]);
				}
			}, GUIStyle.none, ref _scenesScroll);
		}


		private void FillStyles() {
			// Navigation
			_headerStyle = Extensions.EditorExtensions.BoldLabelStyle(15, TextAnchor.MiddleCenter);

			// Scenes
			_sceneNameStyle = Extensions.EditorExtensions.BoldLabelStyle(12, TextAnchor.MiddleLeft);
			_scenePathStyle = Extensions.EditorExtensions.LabelStyle(8, TextAnchor.MiddleLeft);
		}

		private void FillSceneData() {
			string[] guids = AssetDatabase.FindAssets("t: Scene");
			_totalScenes = guids.Length;
			_sceneDatas = new SceneData[_totalScenes];

			for (int i = 0; i < _totalScenes; i++) {
				string path = AssetDatabase.GUIDToAssetPath(guids[i]);
				SceneAsset asset = AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)) as SceneAsset;

				_sceneDatas[i] = new SceneData() {
					Name = asset.name,
					Path = path
				};
			}

		}


		private void DrawScene(SceneData sceneData) {
			Extensions.EditorExtensions.Horizontal(() => {
				Extensions.EditorExtensions.Vertical(() => {
					GUILayout.Label(sceneData.Name, _sceneNameStyle);
					GUILayout.Label(sceneData.Path, _scenePathStyle);
				}, GUIStyle.none, GUILayout.ExpandWidth(true));


				GUILayout.FlexibleSpace();

				Extensions.EditorExtensions.Horizontal(() => {
					DrawButton(Extensions.IconExtensions.GetHome(), () => ChangeScene(sceneData.Path), SceneHeight, SceneHeight);
					DrawButton(Extensions.IconExtensions.GetBookClosed(), () => PingScene(sceneData.Path), SceneHeight, SceneHeight);
				}, GUIStyle.none);
			}, "Box", GUILayout.ExpandWidth(true), GUILayout.Height(SceneHeight));
		}

		private void ChangeScene(string path) {
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				EditorSceneManager.OpenScene(path);
			}
		}

		private void PingScene(string path) {
			EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(path));
		}


		#region Buttons
		private void DrawButton(GUIContent content, System.Action action) {
			DrawButton(content, action, ButtonWidth, ButtonHeight);
		}

		private void DrawButton(string text, System.Action action) {
			DrawButton(new GUIContent(text), action, ButtonWidth, ButtonHeight);
		}

		private void DrawButton(string text, System.Action action, float width, float height) {
			DrawButton(new GUIContent(text), action, width, height);
		}

		private void DrawButton(GUIContent content, System.Action action, float width, float height) {
			if (GUILayout.Button(content, GUILayout.Width(width), GUILayout.Height(height))) {
				action?.Invoke();
			}
		}
		#endregion
	}
}