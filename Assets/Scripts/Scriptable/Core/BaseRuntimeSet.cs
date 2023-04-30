using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Core
{
    public abstract class BaseRuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private bool isImmutable;
        [SerializeField] private bool clearOnPlay;
        [SerializeField] private List<T> items = new();

        public IEnumerable<T> Items => items;
        public event Action<T> OnValueChanged = _ => { };

        private void OnEnable()
        {
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;
            
            if(clearOnPlay)
                items.Clear();
        }

        public T this[int i]
        {
            get => items[i];
            set
            {
                if (!EqualityComparer<T>.Default.Equals(items[i], value))
                    OnValueChanged.Invoke(value);
                items[i] = value;
            }
        }

        public bool Contains(T item) => items.Contains(item);

        public void Add(T item)
        {
            if (isImmutable)
            {
                Debug.LogWarning(
                    $"An element is been added in the collection '{name}' but it cannot be modified. The operation was ignored.");
                return;
            }

            if (!items.Contains(item))
            {
                items.Add(item);
                OnValueChanged.Invoke(item);
            }
        }

        public void Remove(T item)
        {
            if (isImmutable)
            {
                Debug.LogWarning(
                    $"An element is been removed from the collection '{name}' but it cannot be modified. The operation was ignored.");
                return;
            }

            if (items.Contains(item))
            {
                items.Remove(item);
                OnValueChanged.Invoke(item);
            }
        }
    }
}