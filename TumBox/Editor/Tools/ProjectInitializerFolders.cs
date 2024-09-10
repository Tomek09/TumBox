using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

namespace TumBox.Tools
{
	public static class ProjectInitializerFolders
	{
		private static readonly string DEFAULT_ROOT = string.Empty;
		private static readonly string[] DEFAULT_FOLDERS = new string[]
		{
			"_Import", "Scripts", "Content", "Editor", "Inputs"
		};

		public static void CreateFolders()
		{
			CreateDirectories(DEFAULT_ROOT, DEFAULT_FOLDERS);
			Refresh();
		}

		private static void CreateDirectories(string root, params string[] directories)
		{
			var fullPath = Combine(dataPath, root);
			foreach (var newDirectory in directories)
			{
				var path = Combine(fullPath, newDirectory);
				CreateDirectory(path);
			}
		}
	}
}

