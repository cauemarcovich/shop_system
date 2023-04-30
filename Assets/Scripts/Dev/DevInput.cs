using Events;
using UnityEngine;
using UnityEngine.Serialization;

public class DevInput : MonoBehaviour
{
    [SerializeField] private Canvas buyShop;
    [SerializeField] private Canvas sellShop;
    [SerializeField] private Canvas inventory;
    [SerializeField] private CharacterMovement characterMovement;
    
    private Vector2 _movement;
    
    void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.enabled)
            {
                Debug.LogWarning("Disabling inventory");
                EventManager.TriggerEvent(CharacterEvents.INVENTORY_CLOSE);
            }
            else
            {
                Debug.LogWarning("Enabling inventory");
                EventManager.TriggerEvent(CharacterEvents.INVENTORY_OPEN);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (buyShop.enabled)
            {
                Debug.LogWarning("Disabling buy shop");
                EventManager.TriggerEvent(ShopEvents.CLOSE_BUY_SHOP);
            }
            else
            {
                Debug.LogWarning("Enabling buy shop");
                EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (sellShop.enabled)
            {
                Debug.LogWarning("Disabling sell shop");
                EventManager.TriggerEvent(ShopEvents.CLOSE_SELL_SHOP);
            }
            else
            {
                Debug.LogWarning("Enabling sell shop");
                EventManager.TriggerEvent(ShopEvents.OPEN_SELL_SHOP);
            }
        }
    }

    private void FixedUpdate()
    {
        characterMovement.SetMovement(_movement);
    }
}