using System.IO;
using TumBox.Extensions;
using UnityEngine;

namespace TumBox.Tools
{
	public static class ProjectInitializerManifest
	{
		private static readonly string DEFAULT_MANIFEST_PATH = "Editor/Tools/ProjectManifest.json";

		public static void LoadManifests()
		{
			string content = GetProjectManifest();
			ReplacePackageFile(content);
		}

		private static string GetProjectManifest()
		{
			TextAsset content = TumBoxPreferences.LoadAsset<TextAsset>(DEFAULT_MANIFEST_PATH);
			return content.text;
		}

		private static void ReplacePackageFile(string contents)
		{
			var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
			File.WriteAllText(existing, contents);
			UnityEditor.PackageManager.Client.Resolve();
		}
	}
}

