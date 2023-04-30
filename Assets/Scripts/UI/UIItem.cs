using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI itemName;

        private Item _item;
        public Item Item => _item;

        public void SetItemData(Item item)
        {
            _item = item;
            
            icon.sprite = item.Sprite;
            itemName.text = item.Name;
        }
    }
}