using Events;
using UnityEngine;

namespace Inputs
{
    public class PlayerInputPanelTracker : MonoBehaviour
    {
        public bool IsBuyShopOpen { get; private set; }     
        public bool IsSellShopOpen { get; private set; }
        public bool IsInventoryOpen { get; private set; }
        public bool IsDialogueOpen { get; private set; }

        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.OPEN_BUY_SHOP, SetBuyShopOpen);
            EventManager.StartListening(ShopEvents.OPEN_SELL_SHOP, SetSellShopOpen);
            EventManager.StartListening(CharacterEvents.INVENTORY_OPEN, SetInventoryOpen);
            EventManager.StartListening(CharacterEvents.DIALOGUE_OPEN, SetDialogueOpen);
            EventManager.StartListening(ShopEvents.CLOSE_BUY_SHOP, SetBuyShopClose);
            EventManager.StartListening(ShopEvents.CLOSE_SELL_SHOP, SetSellShopClose);
            EventManager.StartListening(CharacterEvents.INVENTORY_CLOSE, SetInventoryClose);
            EventManager.StartListening(CharacterEvents.DIALOGUE_CLOSE, SetDialogueClose);
        }

        private void OnDisable()
        {
            EventManager.StopListening(ShopEvents.OPEN_BUY_SHOP, SetBuyShopOpen);
            EventManager.StopListening(ShopEvents.OPEN_SELL_SHOP, SetSellShopOpen);
            EventManager.StopListening(CharacterEvents.INVENTORY_OPEN, SetInventoryOpen);
            EventManager.StopListening(CharacterEvents.DIALOGUE_OPEN, SetDialogueOpen);
            EventManager.StopListening(ShopEvents.CLOSE_BUY_SHOP, SetBuyShopClose);
            EventManager.StopListening(ShopEvents.CLOSE_SELL_SHOP, SetSellShopClose);
            EventManager.StopListening(CharacterEvents.INVENTORY_CLOSE, SetInventoryClose);
            EventManager.StopListening(CharacterEvents.DIALOGUE_CLOSE, SetDialogueClose);
        }

        private void SetBuyShopOpen() => IsBuyShopOpen = true;
        private void SetBuyShopClose() => IsBuyShopOpen = false;
        private void SetSellShopOpen() => IsSellShopOpen = true;
        private void SetSellShopClose() => IsSellShopOpen = false;
        private void SetInventoryOpen() => IsInventoryOpen = true;
        private void SetInventoryClose() => IsInventoryOpen = false;
        private void SetDialogueOpen(object dialogue) => IsDialogueOpen = true;
        private void SetDialogueClose() => IsDialogueOpen = false;

        public bool HasAnyWindowOpen() => IsBuyShopOpen || IsSellShopOpen || IsInventoryOpen || IsDialogueOpen;
    }
}