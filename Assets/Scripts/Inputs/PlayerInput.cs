using Character;
using Events;
using UnityEngine;

namespace Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private PlayerInputPanelTracker panelTracker;

        private Vector2 _movement;

        void Update()
        {
            if (!panelTracker.HasAnyWindowOpen())
            {
                CacheMoveInput();
                OpenInventory();
                HandleInteraction();
            }
            else
            {
                if (panelTracker.IsInventoryOpen)
                {
                    OpenInventory();
                }
            }

            ClosePanel();
        }

        private void FixedUpdate()
        {
            characterMovement.SetMovement(_movement);
        }

        public void CacheMoveInput()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.y = Input.GetAxis("Vertical");
        }

        private void OpenInventory()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                EventManager.TriggerEvent(panelTracker.IsInventoryOpen
                    ? CharacterEvents.INVENTORY_CLOSE
                    : CharacterEvents.INVENTORY_OPEN);
            }
        }

        public void HandleInteraction()
        {
            if (Input.GetButtonDown("Interaction"))
            {
                var moveDirection = characterMovement.MoveDirection;

                RaycastHit2D[] hits = Physics2D.RaycastAll(characterMovement.transform.position, moveDirection, .35f);
                if (hits.Length == 0) return;

                for (int i = 0; i < hits.Length; i++)
                {
                    var hit = hits[i];
                    if (hit.collider.isTrigger)
                    {
                        if (hit.collider.TryGetComponent(out InteractableHandler interactableHandler))
                        {
                            interactableHandler.Interact();
                            break;
                        }
                    }
                }
            }
        }

        private void ClosePanel()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (panelTracker.IsBuyShopOpen) EventManager.TriggerEvent(ShopEvents.CLOSE_BUY_SHOP);
                if (panelTracker.IsSellShopOpen) EventManager.TriggerEvent(ShopEvents.CLOSE_SELL_SHOP);
                if (panelTracker.IsInventoryOpen) EventManager.TriggerEvent(CharacterEvents.INVENTORY_CLOSE);
                if (panelTracker.IsDialogueOpen) EventManager.TriggerEvent(CharacterEvents.DIALOGUE_CLOSE);
            }
        }
    }
}