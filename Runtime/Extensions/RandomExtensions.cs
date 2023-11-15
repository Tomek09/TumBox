using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TumBox.Extensions {
	public static class RandomExtensions {
		public static float GetRandom(this Vector2 range) {
			return Random.Range(range.x, range.y);
		}

		public static int GetRandom(this Vector2Int range) {
			return Random.Range(range.x, range.y);
		}

		public static T GetRandom<T>(this ICollection<T> collection) {
			int count = collection.Count;
			if (count == 0) {
				return default;
			}

			int index = Random.Range(0, count);
			return collection.ElementAt(index);
		}

		public static T GetRandom<T>() where T : System.Enum {
			if (System.Enum.GetValues(typeof(T)) is not T[] enumArray || enumArray.Length == 0) {
				throw new System.InvalidOperationException("Enum has no values.");
			}

			return enumArray.GetRandom();
		}
	}
}