using System.Linq;
using Scriptable.Core;
using UnityEngine;

namespace Character
{
    public class UIInventoryItemContainer : MonoBehaviour
    {
        [SerializeField] private ItemRuntimeSet inventorySet;
        [SerializeField] private UIInventoryItem inventoryItemPrefab;

        private void Start()
        {
            Refresh();
        }
        
        private void OnEnable() => inventorySet.OnValueChanged += Refresh;
        private void OnDisable() => inventorySet.OnValueChanged -= Refresh;
        
        public void Refresh(object item) => Refresh();
        public void Refresh()
        {
            for (int i = 0; i < inventorySet.Items.Count(); i++)
            {
                var inventoryItem = Instantiate(inventoryItemPrefab, transform);
                inventoryItem.SetItem(inventorySet[i]);
            }
        }
    }
}