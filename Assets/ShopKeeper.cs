using Events;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public void ShowBuyStore()
    {
        EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
        
    }
}