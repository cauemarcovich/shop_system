using System.Collections.Generic;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

public class CharacterOutfitHandler : MonoBehaviour
{
    [SerializeField] private ItemRuntimeSet equippedItemsVariable;

    [Header("SpriteRenderer References")]
    [SerializeField] private SpriteRenderer hairSpriteRenderer;

    [SerializeField] private SpriteRenderer bodySpriteRenderer;
    [SerializeField] private SpriteRenderer pantsSpriteRenderer;

    private List<Item> _equippedItems = new() { };

    public void Equip(Item item)
    {
        if (_equippedItems.TryGetFirstByItemType(item.Type, out Item equippedItem))
        {
            Unequip(equippedItem);
        }

        _equippedItems.Add(item);
        if (equippedItemsVariable != null)
        {
            equippedItemsVariable.Add(item);
        }

        UpdateSprites();
    }

    public void Unequip(Item item)
    {
        _equippedItems.Remove(item);
        if (equippedItemsVariable != null)
        {
            equippedItemsVariable.Remove(item);
        }

        UpdateSprites();
    }

    private void UpdateSprites()
    {
        _equippedItems.TryGetFirstByItemType(ItemType.Hair, out Item hairEquipped);
        hairSpriteRenderer.sprite = hairEquipped != null ? hairEquipped.Sprite : null;

        _equippedItems.TryGetFirstByItemType(ItemType.Body, out Item bodyEquipped);
        bodySpriteRenderer.sprite = bodyEquipped != null ? bodyEquipped.Sprite : null;

        _equippedItems.TryGetFirstByItemType(ItemType.Pants, out Item pantsEquipped);
        pantsSpriteRenderer.sprite = pantsEquipped != null ? pantsEquipped.Sprite : null;
    }
}