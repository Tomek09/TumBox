﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions {
	public static class IconExtensions {

		// CORE
		private static Texture2D _TumBoxIcon;

		// DEFAULT
		private static Texture2D _bookClosedlIcon;
		private static Texture2D _bookOpenIcon;
		private static Texture2D _flagIcon;
		private static Texture2D _homeIcon;
		private static Texture2D _lockClosedIcon;
		private static Texture2D _lockOpenIcon;
		private static Texture2D _lockRhombusIcon;
		private static Texture2D _lockRhombusOutlineIcon;
		private static Texture2D _skullIcon;


		public static GUIContent GetLogo(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _TumBoxIcon, "logo.png");

		public static GUIContent GetBookClosed(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _bookClosedlIcon, "book_closed.png");
		public static GUIContent GetBookOpen(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _bookOpenIcon, "book_open.png");
		public static GUIContent GetFlag(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _flagIcon, "flag.png");
		public static GUIContent GetHome(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _homeIcon, "home.png");
		public static GUIContent GetLockClosed(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockClosedIcon, "lock_closed.png");
		public static GUIContent GetLockOpen(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockOpenIcon, "lock_open.png");
		public static GUIContent GetRhombusFill(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockRhombusIcon, "rhombus.png");
		public static GUIContent GetRhombus(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockRhombusOutlineIcon, "rhombus_outline.png");
		public static GUIContent GetSkull(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _skullIcon, "skull.png");


		private static GUIContent GetContent(string text, string tooltip, ref Texture2D texture, string fileName) {
			 return new GUIContent(text, GetTexture(ref texture, fileName), tooltip);
		}


		// -- HELPERS -- 
		private static Texture2D GetTexture(ref Texture2D texture, string fileName) {
			if (texture == null)
				texture = LoadFromAsset<Texture2D>("Editor/Icons/" + fileName);

			return texture;
		}

		public static T LoadFromAsset<T>(string relativePath) where T : UnityEngine.Object {
			var assetPath = Path.Combine(TumBoxPreferences.HomeFolder, relativePath);
			var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
			if (!asset) {
				Debug.LogError(string.Format("Missing Icon: {0}", assetPath));
			}
			return asset;
		}
	}
}