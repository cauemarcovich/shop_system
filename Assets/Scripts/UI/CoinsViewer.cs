using Scriptable.Core;
using TMPro;
using UnityEngine;

namespace Character
{
    public class CoinsViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private IntVariable playerCoinsVariable;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable() => playerCoinsVariable.OnValueChanged += Refresh;
        private void OnDisable() => playerCoinsVariable.OnValueChanged -= Refresh;

        public void Refresh()
        {
            textMesh.text = playerCoinsVariable.Value.ToString();
        }
    }
}