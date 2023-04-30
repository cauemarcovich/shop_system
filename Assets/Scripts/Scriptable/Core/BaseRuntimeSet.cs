using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Core
{
    public abstract class BaseRuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private bool isImmutable;
        [SerializeField] private List<T> items = new();
        
        public List<T> Items => items;
        
        public void Add(T item)
        {
            if (isImmutable)
            {
                Debug.LogWarning($"An element is been added in the collection '{name}' but it cannot be modified. The operation was ignored.");
                return;
            }
            if (!items.Contains(item))
                items.Add(item);
        }

        public void Remove(T item)
        {
            if (isImmutable)
            {
                Debug.LogWarning($"An element is been removed from the collection '{name}' but it cannot be modified. The operation was ignored.");
                return;
            }
            if (items.Contains(item))
                items.Remove(item);
        }
    }
}