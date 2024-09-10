using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions
{
	public static class EditorExtensions
	{
		public static void Horizontal(System.Action action, GUIStyle style, bool flexibleSpace,
		 params GUILayoutOption[] options)
		{
			GUILayout.BeginHorizontal(style, options);
			if (flexibleSpace) GUILayout.FlexibleSpace();
			action?.Invoke();
			if (flexibleSpace) GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}

		public static void HorizontalScrollView(System.Action action, GUIStyle style, bool flexibleSpace,
			ref Vector2 scroll, params GUILayoutOption[] options)
		{
			GUILayout.BeginHorizontal(style, options);
			scroll = GUILayout.BeginScrollView(scroll);
			if (flexibleSpace) GUILayout.FlexibleSpace();
			action?.Invoke();
			if (flexibleSpace) GUILayout.FlexibleSpace();
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
		}

		public static void Vertical(System.Action action, GUIStyle style, bool flexibleSpace,
			params GUILayoutOption[] options)
		{
			GUILayout.BeginVertical(style, options);
			if (flexibleSpace) GUILayout.FlexibleSpace();
			action?.Invoke();
			if (flexibleSpace) GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
		}

		public static void VerticalScrollView(System.Action action, GUIStyle style, bool flexibleSpace,
			ref Vector2 scroll, params GUILayoutOption[] options)
		{
			GUILayout.BeginVertical(style, options);
			scroll = GUILayout.BeginScrollView(scroll);
			if (flexibleSpace) GUILayout.FlexibleSpace();
			action?.Invoke();
			if (flexibleSpace) GUILayout.FlexibleSpace();
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
		}

		public static GUIStyle CustomStyle(GUIStyle baseStyle, int fontSize = default, TextAnchor alignment = default)
		{
			GUIStyle style = new GUIStyle(baseStyle)
			{
				fontSize = fontSize,
				alignment = alignment
			};
			return style;
		}

		public static void BoldLabel(string content)
		{
			GUIStyle style = CustomStyle(EditorStyles.boldLabel, 12, TextAnchor.MiddleCenter);
			GUILayout.Label(content, style);
		}

		public static void BoldLabel(string content, TextAnchor textAnchor)
		{
			GUIStyle style = CustomStyle(EditorStyles.boldLabel, 12, textAnchor);
			GUILayout.Label(content, style);
		}

		public static void ErrorLabel(string content)
		{
			GUIStyle style = CustomStyle(EditorStyles.boldLabel, 12, TextAnchor.MiddleCenter);
			style.normal = new GUIStyleState() { textColor = Color.red };
			style.focused = new GUIStyleState() { textColor = Color.red };
			style.hover = new GUIStyleState() { textColor = Color.red };
			style.active = new GUIStyleState() { textColor = Color.red };
			GUILayout.Label(content, style);
		}

		public static void Label(string content, int fontSize = 8, TextAnchor alignment = TextAnchor.MiddleLeft)
		{
			GUIStyle style = CustomStyle(EditorStyles.label, fontSize, alignment);
			GUILayout.Label(content, style);
		}

		public static GUIContent RedDot()
		{
			return EditorGUIUtility.IconContent("d_winbtn_mac_close@2x");
		}

		public static GUIContent GreenDot()
		{
			return EditorGUIUtility.IconContent("d_winbtn_mac_max@2x");
		}
	}
}