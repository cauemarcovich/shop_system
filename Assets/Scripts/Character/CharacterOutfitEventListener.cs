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

        private void OnEnable() => EventManager.StartListening(CharacterEvents.ITEM_EQUIPPED, Equip);
        private void OnDisable() => EventManager.StopListening(CharacterEvents.ITEM_EQUIPPED, Equip);

        public void Equip(object item) => _characterOutfitHandler.Equip((Item)item);
    }
}