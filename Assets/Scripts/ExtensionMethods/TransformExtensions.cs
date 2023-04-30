using UnityEngine;

namespace ExtensionMethods
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform tr)
        {
            foreach (Transform child in tr)
            {
                Object.Destroy(child.gameObject);   
            }
        }
    }
}