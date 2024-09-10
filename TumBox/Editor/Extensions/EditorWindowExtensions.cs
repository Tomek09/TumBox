using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions
{
	public class EditorWindowUtility : EditorWindow
	{
		protected void Label(string content, GUIStyle guiStyle, int fontSize, params GUILayoutOption[] options)
		{
			GUIStyle style = new GUIStyle(guiStyle)
			{
				fontSize = fontSize
			};

			GUILayout.Label(content, style, options);
		}

		protected void IconLabel(string iconContent, GUIStyle guiStyle, int fontSize, params GUILayoutOption[] options)
		{
			GUIContent content = EditorGUIUtility.IconContent(iconContent);
			GUIStyle style = new GUIStyle(guiStyle)
			{
				fontSize = fontSize
			};

			GUILayout.Label(content, style, options);
		}

		protected void IconLabel(GUIContent content, GUIStyle guiStyle, int fontSize, params GUILayoutOption[] options)
		{
			GUIStyle style = new GUIStyle(guiStyle)
			{
				fontSize = fontSize
			};

			GUILayout.Label(content, style, options);
		}

		protected void SmallButtonIcon(string iconContent, string tooltip, System.Action action)
		{
			GUIContent content = EditorGUIUtility.IconContent(iconContent);
			content.tooltip = tooltip;
			SmallButtonContent(content, action);
		}

		protected void SmallButtonIcon(GUIContent iconContent, System.Action action)
		{
			SmallButtonContent(iconContent, action);
		}


		protected void SmallButtonContent(string content, string tooltip, System.Action action)
		{
			var guiContent = new GUIContent(content)
			{
				tooltip = tooltip
			};
			SmallButtonContent(guiContent, action);
		}

		protected void SmallButtonContent(GUIContent content, System.Action action)
		{
			if (GUILayout.Button(content, GUILayout.Width(30), GUILayout.Height(30)))
			{
				action?.Invoke();
			}
		}


		protected void ButtonIcon(string iconContent, string tooltip, System.Action action)
		{
			GUIContent content = EditorGUIUtility.IconContent(iconContent);
			content.tooltip = tooltip;
			ButtonContent(content, action);
		}

		protected void ButtonContent(string content, string tooltip, System.Action action, params GUILayoutOption[] options)
		{
			var guiContent = new GUIContent(content)
			{
				tooltip = tooltip
			};
			ButtonContent(guiContent, action, options);
		}

		protected void ButtonContent(GUIContent content, System.Action action, params GUILayoutOption[] options)
		{
			if (GUILayout.Button(content, options))
			{
				action?.Invoke();
			}
		}

	}
}