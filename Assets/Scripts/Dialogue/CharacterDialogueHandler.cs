using Character;
using Events;
using UnityEngine;

namespace Dialogue
{
    public class CharacterDialogueHandler : MonoBehaviour
    {
        [SerializeField] private CharacterOutfitHandler outfitHandler;
        [SerializeField] [TextArea] private string text;
        

        public void ShowDialog()
        {
            var dialogue = new Dialogue()
            {
                Character = outfitHandler,
                Text = text,
                IsShopDialogue = false
            };
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
    }
}
