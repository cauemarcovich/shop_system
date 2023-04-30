using System.Collections;
using System.Collections.Generic;
using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image image;

    private Item _item;
    
    public void SetItem(Item item)
    {
        _item = item;
        image.sprite = item.Sprite;
    }
}
