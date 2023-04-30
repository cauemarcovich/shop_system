using Events;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemRuntimeSet inventorySet;

    private void OnEnable()
    {
        EventManager.StartListening(ShopEvents.BUY_ITEM, AddItem);
    }

    private void OnDisable()
    {
        EventManager.StopListening(ShopEvents.BUY_ITEM, AddItem);
    }

    public void AddItem(object item) => AddItem((Item)item);
    public void AddItem(Item item) => inventorySet.Add(item);
    
    public void RemoveItem(Item item) => inventorySet.Remove(item);
}