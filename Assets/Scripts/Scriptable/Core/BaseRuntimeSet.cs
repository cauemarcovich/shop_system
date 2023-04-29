using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Core
{
    public abstract class BaseRuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private List<T> items = new();
        public List<T> Items => items;
        
        public void Add(T item)
        {
            if (!items.Contains(item))
                items.Add(item);
        }

        public void Remove(T item)
        {
            if (items.Contains(item))
                items.Remove(item);
        }
    }
}