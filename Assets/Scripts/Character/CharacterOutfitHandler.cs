using System.Collections.Generic;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;

namespace Character
{
    public class CharacterOutfitHandler : MonoBehaviour
    {
        [SerializeField] private ItemRuntimeSet equippedItemsSet;

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
            if (equippedItemsSet != null)
            {
                equippedItemsSet.Add(item);
            }

            UpdateSprites();
        }

        public void Unequip(Item item)
        {
            _equippedItems.Remove(item);
            if (equippedItemsSet != null)
            {
                equippedItemsSet.Remove(item);
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
}