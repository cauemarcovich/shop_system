using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptables/Data/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private int price;
        [SerializeField] private SpriteLibraryAsset spriteLibrary;
        [SerializeField] private ItemType type;
        
        public string Name => itemName;
        public int Price => price;
        public int SellPrice => Mathf.CeilToInt(price * .5f);
        public SpriteLibraryAsset SpriteLibrary => spriteLibrary;
        public ItemType Type => type;

        public Sprite GetFirstSprite()
        {
            if (SpriteLibrary == null) return null;

            var labels = spriteLibrary.GetCategoryLabelNames("Down").ToArray();
            Debug.Log("label -> " + labels[0]);
            return spriteLibrary.GetSprite("down", labels[0]);
        }
    }

    public enum ItemType
    {
        None,
        Hair,
        Body,
        Pants
    }
}