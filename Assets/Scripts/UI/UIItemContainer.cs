using System.Linq;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

namespace Shop
{
    public class UIItemContainer : MonoBehaviour
    {
        [SerializeField] protected ItemRuntimeSet currentItemList;
        [SerializeField] protected UIItem itemPrefab;

        private void OnEnable() => currentItemList.OnValueChanged += Refresh;
        private void OnDisable() => currentItemList.OnValueChanged -= Refresh;

        public void Refresh(object item) => Refresh(((Item)item).Type);

        public virtual void Refresh(ItemType itemType = ItemType.None)
        {
            transform.DestroyAllChildren();
            
            for (int i = 0; i < currentItemList.Items.Count(); i++)
            {
                if (itemType != ItemType.None && currentItemList[i].Type != itemType) continue;

                var inventoryItem = Instantiate(itemPrefab, transform);
                inventoryItem.SetItemData(currentItemList[i]);
            }
        }
    }
}