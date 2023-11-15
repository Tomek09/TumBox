using UnityEngine;

namespace TumBox.Extensions {
    public static class StringExtensions {        
        public static string WithColor(this string text, Color color) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
        }
    }
}