using Events;
using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class UIShopItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI price;

        private Item _item;

        public void SetItemData(Item item)
        {
            _item = item;
            
            icon.sprite = item.Sprite;
            itemName.text = item.Name;
            price.text = item.Price.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventManager.TriggerEvent(ShopEvents.BUY_ITEM, _item);
        }
    }
}