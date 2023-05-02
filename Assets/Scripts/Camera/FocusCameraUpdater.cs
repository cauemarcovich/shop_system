using Cinemachine;
using Events;
using UnityEngine;

namespace Camera
{
    public class FocusCameraUpdater : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera shopCam;
        [SerializeField] private CinemachineVirtualCamera inventoryCam;
        [SerializeField] private int disablePriority;
        [SerializeField] private int enablePriority;
    
        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.OPEN_BUY_SHOP, ChangeToShopCamera);
            EventManager.StartListening(ShopEvents.OPEN_SELL_SHOP, ChangeToShopCamera);
            EventManager.StartListening(CharacterEvents.INVENTORY_OPEN, ChangeToInventoryCamera);
            EventManager.StartListening(ShopEvents.CLOSE_BUY_SHOP, ChangeToPlayerCamera);
            EventManager.StartListening(ShopEvents.CLOSE_SELL_SHOP, ChangeToPlayerCamera);
            EventManager.StartListening(CharacterEvents.INVENTORY_CLOSE, ChangeToPlayerCamera);
        }
        
        private void OnDisable()
        {
            EventManager.StopListening(ShopEvents.OPEN_BUY_SHOP, ChangeToShopCamera);
            EventManager.StopListening(ShopEvents.OPEN_SELL_SHOP, ChangeToShopCamera);
            EventManager.StopListening(CharacterEvents.INVENTORY_OPEN, ChangeToInventoryCamera);
            EventManager.StopListening(ShopEvents.CLOSE_BUY_SHOP, ChangeToPlayerCamera);
            EventManager.StopListening(ShopEvents.CLOSE_SELL_SHOP, ChangeToPlayerCamera);
            EventManager.StopListening(CharacterEvents.INVENTORY_CLOSE, ChangeToPlayerCamera);
        }

        private void ChangeToPlayerCamera()
        {
            shopCam.Priority = disablePriority;
            inventoryCam.Priority = disablePriority;
        }
    
        private void ChangeToShopCamera()
        {
            shopCam.Priority = enablePriority;
        }
        
        private void ChangeToInventoryCamera()
        {
            inventoryCam.Priority = enablePriority;
        }
    }
}
