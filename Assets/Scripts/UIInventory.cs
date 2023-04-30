using Events;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    private void OnEnable()
    {
        EventManager.StartListening(CharacterEvents.INVENTORY_OPEN, ShowInventoryUI);
        EventManager.StartListening(CharacterEvents.INVENTORY_CLOSE, HideInventoryUI);
    }
    
    private void OnDisable()
    {
        EventManager.StopListening(CharacterEvents.INVENTORY_OPEN, ShowInventoryUI);
        EventManager.StopListening(CharacterEvents.INVENTORY_CLOSE, HideInventoryUI);
    }

    public void ShowInventoryUI() => canvas.enabled = true;
    public void HideInventoryUI() => canvas.enabled = false;
}
