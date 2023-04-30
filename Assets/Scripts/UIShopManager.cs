using Events;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void OnEnable()
    {
        EventManager.StartListening(ShopEvents.OPEN_SHOP, ShowShopUI);
        EventManager.StartListening(ShopEvents.CLOSE_SHOP, HideShopUI);
    }
    
    private void OnDisable()
    {
        EventManager.StopListening(ShopEvents.OPEN_SHOP, ShowShopUI);
        EventManager.StopListening(ShopEvents.CLOSE_SHOP, HideShopUI);
    }

    public void ShowShopUI() => canvas.enabled = true;
    public void HideShopUI() => canvas.enabled = false;
}