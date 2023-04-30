using System;
using Character;
using Events;
using UnityEngine;

namespace Dev
{
    public class DevInput : MonoBehaviour
    {
        [SerializeField] private Canvas buyShop;
        [SerializeField] private Canvas sellShop;
        [SerializeField] private Canvas inventory;
        [SerializeField] private CharacterMovement characterMovement;

        private Vector2 _movement;

        private Ray ray;

        void Update()
        {
            CacheInput();
            HandleInventory();
            HandleBuyShop();
            HandleSellShop();
            HandleInteraction();
        }

        private void FixedUpdate()
        {
            characterMovement.SetMovement(_movement);
        }

        public void CacheInput()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.y = Input.GetAxis("Vertical");
        }

        public void HandleInventory()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (inventory.enabled)
                {
                    Debug.LogWarning("Disabling inventory");
                    EventManager.TriggerEvent(CharacterEvents.INVENTORY_CLOSE);
                }
                else
                {
                    Debug.LogWarning("Enabling inventory");
                    EventManager.TriggerEvent(CharacterEvents.INVENTORY_OPEN);
                }
            }
        }

        public void HandleBuyShop()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (buyShop.enabled)
                {
                    Debug.LogWarning("Disabling buy shop");
                    EventManager.TriggerEvent(ShopEvents.CLOSE_BUY_SHOP);
                }
                else
                {
                    Debug.LogWarning("Enabling buy shop");
                    EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
                }
            }
        }

        public void HandleSellShop()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (sellShop.enabled)
                {
                    Debug.LogWarning("Disabling sell shop");
                    EventManager.TriggerEvent(ShopEvents.CLOSE_SELL_SHOP);
                }
                else
                {
                    Debug.LogWarning("Enabling sell shop");
                    EventManager.TriggerEvent(ShopEvents.OPEN_SELL_SHOP);
                }
            }
        }

        public void HandleInteraction()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                var moveDirection = characterMovement.MoveDirection;

                RaycastHit2D[] hits = Physics2D.RaycastAll(characterMovement.transform.position, moveDirection, .35f);
                if(hits.Length > 0)
                {
                    for (int i = 0; i < hits.Length; i++)
                    {
                        var hit = hits[i];
                        if(hit.collider.isTrigger)
                        {
                            if(hit.collider.TryGetComponent(out InteractableHandler interactableHandler))
                            {
                                interactableHandler.Interact();
                            }
                        }    
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(ray.origin, ray.direction);
        }
    }
}