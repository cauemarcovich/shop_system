using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptables/Data/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private int price;
        [SerializeField] private Sprite sprite;
        
        public string Name => itemName;
        public int Price => price;
        public Sprite Sprite => sprite;
    }
}