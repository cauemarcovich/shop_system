using System.Linq;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

namespace Shop
{
    public class UIShopItemContainer : UIItemContainer
    {
        [SerializeField] private ItemRuntimeSet playerInventory;
       
        public override void Refresh(ItemType itemType = ItemType.None)
        {
            transform.DestroyAllChildren();

            for (int i = 0; i < currentItemList.Items.Count(); i++)
            {
                if (playerInventory.Contains(currentItemList[i])) continue;
                
                if (itemType != ItemType.None && currentItemList[i].Type != itemType) continue;

                var inventoryItem = Instantiate(itemPrefab, transform);
                inventoryItem.SetItemData(currentItemList[i]);
            }
        }
    }
}