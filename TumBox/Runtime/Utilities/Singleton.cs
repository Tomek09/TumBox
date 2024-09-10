using UnityEngine;

namespace TumBox.Utilities
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					GameObject obj = new GameObject
					{
						name = typeof(T).Name,
						hideFlags = HideFlags.HideAndDontSave
					};

					_instance = obj.AddComponent<T>();
				}

				return _instance;
			}
		}

		protected virtual void Awake()
		{
			if (_instance == null)
			{
				_instance = FindFirstObjectByType<T>();
			}
		}

		protected virtual void OnDestroy()
		{
			if (_instance == this)
			{
				_instance = null;
			}
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