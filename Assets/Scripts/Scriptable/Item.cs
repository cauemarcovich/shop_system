using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptables/Data/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private int price;
        [SerializeField] private Sprite sprite;
        [SerializeField] private ItemType type;
        
        public string Name => itemName;
        public int Price => price;
        public Sprite Sprite => sprite;
        public ItemType Type => type;
    }

    public enum ItemType
    {
        None,
        Hair,
        Body,
        Pants
    }
}