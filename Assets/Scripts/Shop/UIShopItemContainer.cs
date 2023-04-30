using System.Linq;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop
{
    public class UIShopItemContainer : MonoBehaviour
    {
        [SerializeField] private UIShopItem uiShopItemPrefab;
        [SerializeField] private ItemRuntimeSet currentItemList;
        [SerializeField] private ItemRuntimeSet playerInventory;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable() => playerInventory.OnValueChanged += Refresh;
        private void OnDisable() => playerInventory.OnValueChanged -= Refresh;

        public void SetItemList(ItemRuntimeSet itemList)
        {
            currentItemList = itemList;
            Refresh();
        }

        public void Refresh(Item item) => Refresh();

        public void Refresh()
        {
            Debug.Log("Refreshing inventory");

            transform.DestroyAllChildren();

            for (int i = 0; i < currentItemList.Items.Count(); i++)
            {
                if (playerInventory.Contains(currentItemList[i])) continue;

                var uiShopItem = Instantiate(uiShopItemPrefab, transform);
                uiShopItem.SetItemData(currentItemList[i]);
            }
        }
    }
}