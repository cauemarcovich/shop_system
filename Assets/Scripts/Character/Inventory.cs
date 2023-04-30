using Events;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

namespace Character
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private IntVariable coinsVariable; 
        [SerializeField] private ItemRuntimeSet inventorySet;

        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.BUY_ITEM, AddItem);
            EventManager.StartListening(ShopEvents.SELL_ITEM, RemoveItem);
        }

        private void OnDisable()
        {
            EventManager.StopListening(ShopEvents.BUY_ITEM, AddItem);
            EventManager.StopListening(ShopEvents.SELL_ITEM, RemoveItem);
        }

        public void AddItem(object item) => AddItem((Item)item);
        public void AddItem(Item item) => inventorySet.Add(item);
    
        public void RemoveItem(object item) => RemoveItem((Item)item);
        public void RemoveItem(Item item) => inventorySet.Remove(item);
    }
}