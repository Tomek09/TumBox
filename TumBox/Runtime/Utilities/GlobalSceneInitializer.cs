using UnityEngine;

namespace TumBox.Utilities {
	public class GlobalSceneInitializer {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod() {
            Object globalPrefab = Resources.Load("_Global");
            if(globalPrefab == null) {
                return;
            }

            Object global = Object.Instantiate(globalPrefab);
            Object.DontDestroyOnLoad(global);
        }
    }
}