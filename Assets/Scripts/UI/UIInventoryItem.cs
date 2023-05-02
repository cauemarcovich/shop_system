using Events;
using Scriptable.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIInventoryItem : UIItem
    {
        [SerializeField] private ItemRuntimeSet equippedItems;
        
        [Header("Button References")]
        [SerializeField] private Button equipButton;
        [SerializeField] private Button unequipButton;

        private void Start()
        {
            RefreshButtons();
        }

        private void OnEnable() => equippedItems.OnValueChanged += RefreshButtons;
        private void OnDisable() => equippedItems.OnValueChanged -= RefreshButtons;

        public void RefreshButtons(object item) => RefreshButtons();
        public void RefreshButtons()
        {
            var isEquipped = equippedItems.Contains(Item);
            equipButton.gameObject.SetActive(!isEquipped);
            unequipButton.gameObject.SetActive(isEquipped);
        }

        public void Equip()
        {
            AudioManager.Instance.PlayClick();
            EventManager.TriggerEvent(CharacterEvents.ITEM_EQUIPPED, Item);
        }

        public void Unequip()
        {
            AudioManager.Instance.PlayClick();
            EventManager.TriggerEvent(CharacterEvents.ITEM_UNEQUIPPED, Item);
        }
    }
}