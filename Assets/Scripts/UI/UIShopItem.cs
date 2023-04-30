using Events;

namespace Shop
{
    public class UIShopItem : UIItem
    {
        public void Buy()
        {
            EventManager.TriggerEvent(ShopEvents.BUY_ITEM, Item);
        }
        
        public void Sell()
        {
            EventManager.TriggerEvent(ShopEvents.SELL_ITEM, Item);
        }
    }
}