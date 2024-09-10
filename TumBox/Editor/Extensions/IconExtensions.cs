using System.IO;
using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions
{
	public static class IconExtensions
	{

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


		public static GUIContent Logo(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _TumBoxIcon, "logo.png");

		public static GUIContent BookClosed(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _bookClosedlIcon, "book_closed.png");
		public static GUIContent BookOpen(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _bookOpenIcon, "book_open.png");
		public static GUIContent Flag(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _flagIcon, "flag.png");
		public static GUIContent Home(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _homeIcon, "home.png");
		public static GUIContent LockClosed(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockClosedIcon, "lock_closed.png");
		public static GUIContent LockOpen(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockOpenIcon, "lock_open.png");
		public static GUIContent RhombusFill(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockRhombusIcon, "rhombus.png");
		public static GUIContent Rhombus(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _lockRhombusOutlineIcon, "rhombus_outline.png");
		public static GUIContent Skull(string text = default, string tooltip = default) => GetContent(text, tooltip, ref _skullIcon, "skull.png");

		private static GUIContent GetContent(string text, string tooltip, ref Texture2D texture, string fileName)
		{
			return new GUIContent(text, GetTexture(ref texture, fileName), tooltip);
		}


		// -- HELPERS -- 
		private static Texture2D GetTexture(ref Texture2D texture, string fileName)
		{
			if (texture == null)
			{
				texture = TumBoxPreferences.LoadAsset<Texture2D>("Editor/Icons/" + fileName);
			}

			return texture;
		}
	}
}