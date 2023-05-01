using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterOutfitHandler))]
public class CharacterOutfitInitializer : MonoBehaviour
{
    [SerializeField] private ItemRuntimeSet outfitsCollection;

    private CharacterOutfitHandler _outfitHandler;

    private void Start()
    {
        _outfitHandler = GetComponent<CharacterOutfitHandler>();

        LoadRandomEquips();
    }

    private void LoadRandomEquips(bool overrideEquips = false)
    {
        if (outfitsCollection == null)
        {
            Debug.LogWarning("Cannot load the outfit because de outfitsCollection wasn't assigned.");
            return;
        }
        
        List<Item> items;
        if (overrideEquips || _outfitHandler.HairEquipped == null)
        {
            items = outfitsCollection.Items.GetAllByItemType(ItemType.Hair).ToList();
            GetRandomAndLoad(items); 
        }
        if (overrideEquips || _outfitHandler.BodyEquipped == null)
        {
            items = outfitsCollection.Items.GetAllByItemType(ItemType.Body).ToList();
            GetRandomAndLoad(items);
        }
        if (overrideEquips || _outfitHandler.PantsEquipped == null)
        {
            items = outfitsCollection.Items.GetAllByItemType(ItemType.Pants).ToList();
            GetRandomAndLoad(items); 
        }
    }

    private void GetRandomAndLoad(IList<Item> items)
    {
        if (items.Count > 0)
        {
            var item = items[Random.Range(0, outfitsCollection.Items.Count())];
            _outfitHandler.Equip(item);
        }
    }
    
    [ContextMenu("Load Random Equips")]
    void LoadRandomEquipsContextMenu()
    {
        _outfitHandler = GetComponent<CharacterOutfitHandler>();
        LoadRandomEquips(true);
    }
}
