using Cinemachine;
using Events;
using UnityEngine;

namespace Camera
{
    public class ShopCameraUpdater : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera playerCam;
        [SerializeField] private CinemachineVirtualCamera shopCam;
    
        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.OPEN_BUY_SHOP, ChangeToShopCamera);
            EventManager.StartListening(ShopEvents.OPEN_SELL_SHOP, ChangeToShopCamera);
            EventManager.StartListening(ShopEvents.CLOSE_BUY_SHOP, ChangeToPlayerCamera);
            EventManager.StartListening(ShopEvents.CLOSE_SELL_SHOP, ChangeToPlayerCamera);
        }

        private void ChangeToPlayerCamera()
        {
            shopCam.Priority = playerCam.Priority - 1;
        }
    
        private void ChangeToShopCamera()
        {
            shopCam.Priority = playerCam.Priority + 1;
        }
    }
}
