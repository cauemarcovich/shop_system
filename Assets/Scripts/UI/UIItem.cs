using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI itemName;

        private Item _item;
        public Item Item => _item;

        public virtual void SetItemData(Item item)
        {
            _item = item;
            
            icon.sprite = item.Sprite;
            itemName.text = item.Name;
        }
    }
}