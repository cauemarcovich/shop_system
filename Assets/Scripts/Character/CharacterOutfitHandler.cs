using System.Linq;
using ExtensionMethods;
using Scriptable;
using Scriptable.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;
using Random = UnityEngine.Random;

namespace Character
{
    public class CharacterOutfitHandler : MonoBehaviour
    {
        [SerializeField] private Item initialHair;
        [SerializeField] private Item initialBody;
        [SerializeField] private Item initialPants;

        [Header("SpriteLibrary References")]
        [SerializeField] private SpriteLibrary hairSpriteLibrary;
        [SerializeField] private SpriteLibrary bodySpriteLibrary;
        [SerializeField] private SpriteLibrary pantsSpriteLibrary;

        [Header("Equipped Items Set (Optional)")]
        [SerializeField] private ItemRuntimeSet equippedItemsSet;

        private Item _hair;
        public Item Hair => _hair;
        private Item _body;
        public Item Body => _body;
        private Item _pants;
        public Item Pants => _pants;

        private void Start()
        {
            _hair = initialHair;
            _body = initialBody;
            _pants = initialPants;
            UpdateSprites();
        }

        public void Equip(Item item)
        {
            Unequip(item.Type);
            CacheItem(item);
            UpdateSprites();
        }

        public void Unequip(Item item)
        {
            ClearCache(item);
            UpdateSprites();
        }

        public void Unequip(ItemType itemType)
        {
            var item = itemType switch
            {
                ItemType.Hair => _hair,
                ItemType.Body => _body,
                ItemType.Pants => _pants,
                _ => null
            };

            if (item != null)
                Unequip(item);
        }

        public void UnequipAll()
        {
            if (_hair) ClearCache(_hair);
            if (_body) ClearCache(_body);
            if (_pants) ClearCache(_pants);
            UpdateSprites();
        }

        private void CacheItem(Item item)
        {
            if (item.Type == ItemType.Hair) _hair = item;
            if (item.Type == ItemType.Body) _body = item;
            if (item.Type == ItemType.Pants) _pants = item;

            if (equippedItemsSet != null)
            {
                equippedItemsSet.Add(item);
            }
        }

        private void ClearCache(Item item)
        {
            if (item.Type == ItemType.Hair) _hair = null;
            if (item.Type == ItemType.Body) _body = null;
            if (item.Type == ItemType.Pants) _pants = null;

            if (equippedItemsSet != null)
            {
                equippedItemsSet.Remove(item);
            }
        }

        private void UpdateSprites()
        {
            hairSpriteLibrary.spriteLibraryAsset = _hair != null ? _hair.SpriteLibrary : null;
            bodySpriteLibrary.spriteLibraryAsset = _body != null ? _body.SpriteLibrary : null;
            pantsSpriteLibrary.spriteLibraryAsset = _pants != null ? _pants.SpriteLibrary : null;
        }

        private ItemRuntimeSet _shopItemsSets;

        [ContextMenu("Load Random Equips")]
        void LoadRandomEquipsContextMenu()
        {
            if (_shopItemsSets == null)
            {
                var shopItemsGuid = AssetDatabase.FindAssets("ShopItems")[0];
                var shopItemsPath = AssetDatabase.GUIDToAssetPath(shopItemsGuid);
                _shopItemsSets = AssetDatabase.LoadAssetAtPath<ItemRuntimeSet>(shopItemsPath);
            }

            UnequipAll();

            Item[] items;

            items = _shopItemsSets.Items.GetAllByItemType(ItemType.Hair).ToArray();
            ChooseRandomAndEquip(items);
            initialHair = _hair;

            items = _shopItemsSets.Items.GetAllByItemType(ItemType.Body).ToArray();
            ChooseRandomAndEquip(items);
            initialBody = _body;

            items = _shopItemsSets.Items.GetAllByItemType(ItemType.Pants).ToArray();
            ChooseRandomAndEquip(items);
            initialPants = _pants;
        }

        void ChooseRandomAndEquip(Item[] items)
        {
            if (items.Length > 0)
            {
                var item = items[Random.Range(0, items.Count())];
                Equip(item);
            }
        }
    }
}