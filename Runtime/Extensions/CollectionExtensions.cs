using System.Collections.Generic;

namespace TumBox.Extensions {
	public static class CollectionExtensions {
		public static void Shuffle<T>(this IList<T> collection) {
			System.Random random = new System.Random();
			int n = collection.Count;
			while (n > 1) {
				n--;
				int k = random.Next(n + 1);
				(collection[k], collection[n]) = (collection[n], collection[k]);
			}
		}
	}
}