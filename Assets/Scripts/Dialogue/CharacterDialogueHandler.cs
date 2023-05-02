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

        [Header("Button 1 Configuration")]
        [SerializeField] private string button1Name;
        [SerializeField] private UnityEvent button1Event;

        [Header("Button 2 Configuration")]
        [SerializeField] private string button2Name;
        [SerializeField] private UnityEvent button2Event;

        public void ShowDialog()
        {
            var dialogue = new DialogueData()
            {
                CharacterOutfitHandler = outfitHandler,
                Text = text,
                IsShopDialogue = false
            };
            if (button1Event != null)
                dialogue.Button1Config = new DialogueButtonConfig() { Name = button1Name, Event = button1Event };

            if (button1Event != null)
                dialogue.Button2Config = new DialogueButtonConfig() { Name = button2Name, Event = button2Event };
                    
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
    }
}