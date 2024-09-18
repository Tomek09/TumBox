using UnityEngine;

namespace TumBox.Utilities
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{

		private static T _instance = null;

		static public T Instance
		{
			get
			{
				if (_instance == null)
				{
					T[] array = Resources.FindObjectsOfTypeAll<T>();
					for (int a = 0; a < array.Length; a++)
					{
						if (array[a].gameObject.scene.name != null)
						{
							return _instance = array[a];
						}
					}
					return null;
				}
				else
				{
					return _instance;
				}
			}
		}

		protected virtual void Awake()
		{
			_instance = this as T;
		}
	}


	public class SingletonPersistent<T> : MonoBehaviour where T : Component
	{
		public static T Instance { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = FindFirstObjectByType<T>();

				if (Instance == null)
				{
					Instance = this as T;
					DontDestroyOnLoad(this);
				}

			}
		}
	}
}
