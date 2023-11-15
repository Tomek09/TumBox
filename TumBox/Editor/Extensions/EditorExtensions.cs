using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions {
	public static class EditorExtensions {
		public static void Horizontal(System.Action action, GUIStyle style, params GUILayoutOption[] options) {
			GUILayout.BeginHorizontal(style, options);
			action?.Invoke();
			GUILayout.EndHorizontal();
		}

		public static void HorizontalScrollView(System.Action action, GUIStyle style, ref Vector2 scroll, params GUILayoutOption[] options) {
			GUILayout.BeginHorizontal(style, options);
			scroll = GUILayout.BeginScrollView(scroll);
			action?.Invoke();
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
		}

		public static void Vertical(System.Action action, GUIStyle style, params GUILayoutOption[] options) {
			GUILayout.BeginVertical(style, options);
			action?.Invoke();
			GUILayout.EndVertical();
		}

		public static void VerticalScrollView(System.Action action, GUIStyle style, ref Vector2 scroll, params GUILayoutOption[] options) {
			GUILayout.BeginVertical(style, options);
			scroll = GUILayout.BeginScrollView(scroll);
			action?.Invoke();
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
		}

		public static void Label(string content, int fontSize = 12, TextAnchor alignment = TextAnchor.MiddleCenter) {
			GUILayout.Label(content, LabelStyle(fontSize, alignment));
		}

		public static void BoldLabel(string content, int fontSize = 12, TextAnchor alignment = TextAnchor.MiddleCenter) {
			GUILayout.Label(content, BoldLabelStyle(fontSize, alignment));
		}


		public static GUIStyle LabelStyle(int fontSize = 12, TextAnchor alignment = TextAnchor.MiddleCenter) {
			return LabelStyle(EditorStyles.label, fontSize, alignment);
		}

		public static GUIStyle BoldLabelStyle(int fontSize = 12, TextAnchor alignment = TextAnchor.MiddleCenter) {
			return LabelStyle(EditorStyles.boldLabel, fontSize, alignment);
		}

		public static GUIStyle LabelStyle(GUIStyle style, int fontSize, TextAnchor alignment) {
			GUIStyle drawStyle = new GUIStyle(style) {
				fontSize = fontSize,
				alignment = alignment
			};
			return drawStyle;
		}
	}
}