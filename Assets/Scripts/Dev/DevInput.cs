using Events;
using UnityEngine;

public class DevInput : MonoBehaviour
{
    [SerializeField] private Canvas shop;
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

    private void FixedUpdate()
    {
        characterMovement.SetMovement(_movement);
    }
}