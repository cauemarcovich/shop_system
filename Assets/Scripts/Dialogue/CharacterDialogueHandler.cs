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
        [SerializeField] private bool blockAutoInteraction;

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
                IsShopDialogue = false,
                BlockAutoInteraction = blockAutoInteraction
            };
            if (button1Event.GetPersistentEventCount() > 0)
                dialogue.Button1Config = new DialogueButtonConfig() { Name = button1Name, Event = button1Event };

            if (button2Event.GetPersistentEventCount() > 0)
                dialogue.Button2Config = new DialogueButtonConfig() { Name = button2Name, Event = button2Event };
                    
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
    }
}