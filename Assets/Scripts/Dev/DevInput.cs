using Events;
using UnityEngine;

public class DevInput : MonoBehaviour
{
    [SerializeField] private Canvas shop;
    [SerializeField] private Canvas inventory;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.enabled)
            {
                EventManager.TriggerEvent(CharacterEvents.INVENTORY_CLOSE);
            }
            else
            {
                EventManager.TriggerEvent(CharacterEvents.INVENTORY_OPEN);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (shop.enabled)
            {
                Debug.LogWarning("Disabling shop");
                EventManager.TriggerEvent(ShopEvents.CLOSE_SHOP);
            }
            else
            {
                Debug.LogWarning("Enabling shop");
                EventManager.TriggerEvent(ShopEvents.OPEN_SHOP);
            }
        }
    }
}