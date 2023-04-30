using Events;

namespace Shop
{
    public class UIShopItem : UIItem
    {
        public void Buy()
        {
            EventManager.TriggerEvent(ShopEvents.BUY_ITEM, Item);
        }
    }
}