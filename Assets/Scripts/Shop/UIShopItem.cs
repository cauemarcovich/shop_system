using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class UIShopItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI price;

        public void SetItemData(Item item)
        {
            icon.sprite = item.Sprite;
            itemName.text = item.Name;
            price.text = item.Price.ToString();
        }
    }
}