using Events;
using Scriptable;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterOutfitHandler))]
    public class CharacterOutfitEventListener : MonoBehaviour
    {
        private CharacterOutfitHandler _characterOutfitHandler;

        private void Start() => _characterOutfitHandler = GetComponent<CharacterOutfitHandler>();

        private void OnEnable()
        {
            EventManager.StartListening(CharacterEvents.ITEM_EQUIPPED, Equip);
            EventManager.StartListening(CharacterEvents.ITEM_UNEQUIPPED, Unequip);
        }

        private void OnDisable()
        {
            EventManager.StopListening(CharacterEvents.ITEM_EQUIPPED, Equip);
            EventManager.StopListening(CharacterEvents.ITEM_UNEQUIPPED, Unequip);
        }

        public void Equip(object item) => _characterOutfitHandler.Equip((Item)item);
        public void Unequip(object item) => _characterOutfitHandler.Unequip((Item)item);
    }
}