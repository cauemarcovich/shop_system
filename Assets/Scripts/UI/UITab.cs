using System.Collections;
using Scriptable;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UITab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private UIItemContainer itemContainer;

        private IEnumerator Start()
        {
            if (transform.GetSiblingIndex() == 0)
            {
                yield return new WaitForEndOfFrame();
                itemContainer.Refresh(itemType);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            itemContainer.Refresh(itemType);
        }
    }
}