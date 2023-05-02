using Events;
using UnityEngine;

namespace Character
{
    public class ShopKeeper : MonoBehaviour
    {
        public void ShowBuyStore()
        {
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_CLOSE);
            EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
        }
        
        public void ShowSellStore()
        {
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_CLOSE);
            EventManager.TriggerEvent(ShopEvents.OPEN_SELL_SHOP);
        }
    }
}