using Events;
using UnityEngine;

public class DevInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var shopManager = GameObject.FindObjectOfType<UIShopManager>();
            if (shopManager.GetComponent<Canvas>().enabled)
            {
                Debug.Log("Close shop");
                EventManager.TriggerEvent(ShopEvents.CLOSE_SHOP);
            }
            else
            {
                Debug.Log("Open shop");
                EventManager.TriggerEvent(ShopEvents.OPEN_SHOP);
            }
        }
    }
}