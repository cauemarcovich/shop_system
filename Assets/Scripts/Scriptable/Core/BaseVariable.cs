using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Core
{
    public abstract class BaseVariable<T> : ScriptableObject
    {
        [SerializeField] private T initialValue;
        [SerializeField] [HideInInspector] private T runtimeValue;

        private void OnEnable()
        {
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;
            
            runtimeValue = initialValue;
        }

        public T Value
        {
            get => runtimeValue;
            set
            {
                T oldValue = runtimeValue;
                runtimeValue = value;

                if (!EqualityComparer<T>.Default.Equals(oldValue, value))
                    OnValueChanged.Invoke();
            }
        }

        public event Action OnValueChanged = () => { };

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    }
}