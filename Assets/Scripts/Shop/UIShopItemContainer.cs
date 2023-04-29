using ExtensionMethods;
using Scriptable.Core;
using UnityEngine;

namespace Shop
{
    public class UIShopItemContainer : MonoBehaviour
    {
        [SerializeField] private UIShopItem uiItemContentPrefab;
        [SerializeField] private ItemRuntimeSet currentItemList;

        private void Start()
        {
            Refresh();
        }

        public void SetItemList(ItemRuntimeSet itemList)
        {
            currentItemList = itemList;
            Refresh();
        }
        
        public void Refresh()
        {
            transform.DestroyAllChildren();

            for (int i = 0; i < currentItemList.Items.Count; i++)
            {
                var uiShopItem = Instantiate(uiItemContentPrefab, transform);
                uiShopItem.SetItemData(currentItemList.Items[i]);
            }
        }
    }
}