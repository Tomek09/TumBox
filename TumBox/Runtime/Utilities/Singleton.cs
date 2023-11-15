using System.Linq;
using UnityEngine;

namespace TumBox.Utilities {
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		private static T _instance;

		public static T Instance {
			get {
				if (_instance == null) {
					T[] array = Resources.FindObjectsOfTypeAll<T>();
					return (from t in array where t.gameObject.scene.name != null select _instance = t).FirstOrDefault();
				}

				return _instance;
			}
		}

		protected virtual void Awake() {
			_instance = this as T;
		}
	}
}