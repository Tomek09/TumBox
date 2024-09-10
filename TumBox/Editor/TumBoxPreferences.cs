using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TumBox.Extensions
{
	public static class TumBoxPreferences 
	{
		public static string HomeFolderPath => "Packages/com.atom3y.tumbox/";

		public static T LoadAsset<T>(string relativePath) where T : UnityEngine.Object
		{
			try
			{
				var assetPath = Path.Combine(HomeFolderPath, relativePath);
				T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
				return asset;
			}
			catch(Exception ex)
			{
				Debug.LogException(ex);
			}
			return null;
		}
	}
}