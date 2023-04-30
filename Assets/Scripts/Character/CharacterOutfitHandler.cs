using Scriptable;
using UnityEngine;

public class CharacterOutfitHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hair;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer pants;

    public void Equip(Item item)
    {
        var spriteRenderer = item.Type switch {
            ItemType.Hair => hair,
            ItemType.Body => body,
            ItemType.Pants => pants,
            _ => hair
        };

        spriteRenderer.sprite = item.Sprite;
    }
}