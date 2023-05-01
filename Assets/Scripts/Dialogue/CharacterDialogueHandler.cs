using Character;
using Events;
using UnityEngine;

namespace Dialogue
{
    [RequireComponent(typeof(CharacterOutfitHandler))]
    public class CharacterDialogueHandler : MonoBehaviour
    {
        [SerializeField] [TextArea] private string text;

        private CharacterOutfitHandler _outfitHandler;

        private void Awake() => _outfitHandler = GetComponent<CharacterOutfitHandler>();

        public void ShowDialog()
        {
            var dialogue = new Dialogue()
            {
                Character = _outfitHandler,
                Text = text,
                IsShopDialogue = false
            };
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
    }
}
