using Scriptable.Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BaseVariable<>), true)]
    public class VariableEditor : UnityEditor.Editor
    {
        private SerializedProperty _runtimeValueProperty;

        private void OnEnable()
        {
            _runtimeValueProperty = serializedObject.FindProperty("runtimeValue");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                EditorGUILayout.PropertyField(_runtimeValueProperty);
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}