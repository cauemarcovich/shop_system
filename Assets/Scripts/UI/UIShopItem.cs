using Events;
using Scriptable;
using Scriptable.Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIShopItem : UIItem
    {
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private IntVariable playerCoinsVariable;
        [SerializeField] private UIShopItemType shopItemType;

        public override void SetItemData(Item item)
        {
            base.SetItemData(item);
            price.text = shopItemType == UIShopItemType.Buy ? item.Price.ToString() : item.SellPrice.ToString();
        }

        public void Buy()
        {
            AudioManager.Instance.PlayBuySell();
            playerCoinsVariable.Value -= Item.Price;
            EventManager.TriggerEvent(ShopEvents.BUY_ITEM, Item);
        }

        public void Sell()
        {
            AudioManager.Instance.PlayBuySell();
            playerCoinsVariable.Value += Item.SellPrice;
            EventManager.TriggerEvent(ShopEvents.SELL_ITEM, Item);
        }
    }

    public enum UIShopItemType
    {
        Buy,
        Sell
    }
}