using Character;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{
    public class CharacterDialogueHandler : MonoBehaviour
    {
        [SerializeField] private CharacterOutfitHandler outfitHandler;
        [SerializeField] [TextArea] private string text;
        [SerializeField] private UnityEvent button1Event;
        [SerializeField] private UnityEvent button2Event;
        

        public void ShowDialog()
        {
            var dialogue = new Dialogue()
            {
                Character = outfitHandler,
                Text = text,
                IsShopDialogue = false,
                Button1Event = button1Event,
                Button2Event = button2Event
            };
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
    }
}
