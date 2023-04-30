using Scriptable.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shop
{
    public class UITab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ItemRuntimeSet contentList;
        [SerializeField] private UIItemContainer itemContainer;

        public void OnPointerClick(PointerEventData eventData)
        {
            itemContainer.SetItemList(contentList);
        }
    }
}