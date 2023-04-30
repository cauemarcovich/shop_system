using System.Linq;
using Scriptable.Core;
using UnityEngine;

namespace Shop
{
    public class UIItemContainer : MonoBehaviour
    {
        [SerializeField] protected ItemRuntimeSet currentItemList;
        [SerializeField] protected UIItem itemPrefab;

        private void Start()
        {
            Refresh();
        }
        
        private void OnEnable() => currentItemList.OnValueChanged += Refresh;
        private void OnDisable() => currentItemList.OnValueChanged -= Refresh;
        
        public void SetItemList(ItemRuntimeSet itemList)
        {
            currentItemList = itemList;
            Refresh();
        }
        
        public void Refresh(object item) => Refresh();
        public virtual void Refresh()
        {
            for (int i = 0; i < currentItemList.Items.Count(); i++)
            {
                var inventoryItem = Instantiate(itemPrefab, transform);
                inventoryItem.SetItemData(currentItemList[i]);
            }
        }
    }
}