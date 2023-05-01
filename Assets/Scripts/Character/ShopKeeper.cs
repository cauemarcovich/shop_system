using Events;
using UnityEngine;

namespace Character
{
    public class ShopKeeper : MonoBehaviour
    {
        public void ShowBuyStore()
        {
            EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
        }
    }
}