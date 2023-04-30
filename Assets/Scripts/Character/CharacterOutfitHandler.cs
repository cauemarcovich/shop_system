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

    private Item _hair;
    private Item _body;
    private Item _pants;
    
    public void Equip(Item item)
    {
        switch (item.Type){
            case ItemType.Hair: EquipHair(item); break;
            case ItemType.Body: EquipBody(item); break;
            case ItemType.Pants: EquipPants(item); break;
        };
    }

    private void EquipHair(Item newHair)
    {
        UpdateEquippedItems(newHair, _hair);
        _hair = newHair;
        hairSpriteRenderer.sprite = newHair.Sprite;
    }
    
    private void EquipBody(Item newBody)
    {
        UpdateEquippedItems(newBody, _body);
        _body = newBody;
        bodySpriteRenderer.sprite = newBody.Sprite;
    }
    
    private void EquipPants(Item newPants)
    {
        UpdateEquippedItems(newPants, _pants);
        _pants = newPants;
        pantsSpriteRenderer.sprite = newPants.Sprite;
    }

    private void UpdateEquippedItems(Item newValue, Item oldValue)
    {
        if (equippedItemsVariable != null)
        {
            equippedItemsVariable.Remove(oldValue);
            equippedItemsVariable.Add(newValue);
        }
    }
}