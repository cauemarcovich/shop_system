using Events;
using Scriptable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image image;

    private Item _item;
    
    public void SetItem(Item item)
    {
        _item = item;
        image.sprite = item.Sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventManager.TriggerEvent(CharacterEvents.ITEM_EQUIPPED, _item);
    }
}