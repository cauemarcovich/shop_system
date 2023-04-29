using Scriptable.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shop
{
    public class UIShopTab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ItemRuntimeSet contentList;
        [SerializeField] private UIShopItemContainer itemContainer;

        public void OnPointerClick(PointerEventData eventData)
        {
            itemContainer.SetItemList(contentList);
        }
    }
}