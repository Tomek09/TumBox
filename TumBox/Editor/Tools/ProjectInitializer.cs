using UnityEditor;

namespace TumBox.Tools
{
	public static partial class ProjectInitializer
	{
		[MenuItem("TumBox/Initializer/Folders")]
		public static void Folders()
		{
			ProjectInitializerFolders.CreateFolders();
		}

		[MenuItem("TumBox/Initializer/Manifest")]
		public static void Manifests()
		{
			ProjectInitializerManifest.LoadManifests();
		}
	}
}
