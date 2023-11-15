using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions {
	public class PropertyDrawerHelper : PropertyDrawer {
		protected SerializedProperty DrawField(Rect position, SerializedProperty property, int yOffset, GUIContent content) {
			Rect rect = new Rect(position.x, position.y + (yOffset * EditorGUIUtility.singleLineHeight), position.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(rect, property, content);
			return property;
		}

		protected SerializedProperty DrawField(Rect position, SerializedProperty property, string path, int yOffset, GUIContent content) {
			SerializedProperty serializedProperty = FindPropertyRelative(property, path);
			Rect rect = new Rect(position.x, position.y + (yOffset * EditorGUIUtility.singleLineHeight), position.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(rect, serializedProperty, content);
			return serializedProperty;
		}

		protected SerializedProperty FindPropertyRelative(SerializedProperty property, string path) {
			return property.FindPropertyRelative(path);
		}
	
		protected bool PropertyIsEnabled(SerializedProperty property, string path) {
			SerializedProperty serializedProperty = property.FindPropertyRelative(path);
			return serializedProperty.boolValue;
		}
	}
}