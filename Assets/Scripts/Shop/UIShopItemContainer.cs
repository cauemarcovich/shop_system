using System.Linq;
using ExtensionMethods;
using Scriptable.Core;
using UnityEngine;

namespace Shop
{
    public class UIShopItemContainer : UIItemContainer
    {
        [SerializeField] private ItemRuntimeSet playerInventory;
       
        public override void Refresh()
        {
            transform.DestroyAllChildren();

            for (int i = 0; i < currentItemList.Items.Count(); i++)
            {
                if (playerInventory.Contains(currentItemList[i])) continue;

                var uiShopItem = Instantiate(itemPrefab, transform);
                uiShopItem.SetItemData(currentItemList[i]);
            }
        }
    }
}