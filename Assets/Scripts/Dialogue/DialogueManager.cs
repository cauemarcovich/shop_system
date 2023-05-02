using Character;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private CharacterPreviewOutfitHandler characterPreviewOutfitHandler;
        [SerializeField] private TextMeshProUGUI textMesh;

        [SerializeField] private Button button1;
        [SerializeField] private Button button2;

        [Header("Anchors")]
        [SerializeField] private float shopMinXAnchor;

        private RectTransform _rect;

        private void Awake() => _rect = GetComponent<RectTransform>();

        private void OnEnable()
        {
            EventManager.StartListening(CharacterEvents.DIALOGUE_OPEN, ShowDialogue);
        }

        private void OnDisable()
        {
            EventManager.StartListening(CharacterEvents.DIALOGUE_OPEN, ShowDialogue);
        }

        public void ShowDialogue(object text) => ShowDialogue((DialogueData)text);

        public void ShowDialogue(DialogueData dialogueData)
        {
            ChangeAnchors(dialogueData.IsShopDialogue);

            characterPreviewOutfitHandler.SetPreviewOutfit(dialogueData.CharacterOutfitHandler.Hair, dialogueData.CharacterOutfitHandler.Body,
                dialogueData.CharacterOutfitHandler.Pants);
            textMesh.text = dialogueData.Text;

            ManageButton(button1, dialogueData.Button1Config);
            ManageButton(button2, dialogueData.Button2Config);
        }

        private void ChangeAnchors(bool isShopDialogue)
        {
            var minAnchor = _rect.anchorMin;
            minAnchor.x = isShopDialogue ? shopMinXAnchor : 0f;
            _rect.anchorMin = minAnchor;
        }

        private void ManageButton(Button button, DialogueButtonConfig buttonConfig)
        {
            if (buttonConfig != null)
            {
                button.gameObject.SetActive(true);
                button.GetComponentInChildren<TextMeshProUGUI>().text = buttonConfig.Name;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(buttonConfig.Event.Invoke);
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public class DialogueData
    {
        public CharacterOutfitHandler CharacterOutfitHandler { get; set; }
        public string Text { get; set; }
        public bool IsShopDialogue { get; set; }
        public DialogueButtonConfig Button1Config { get; set; }
        public DialogueButtonConfig Button2Config { get; set; }
    }

    public class DialogueButtonConfig
    {
        public string Name {get;set;}
        public UnityEvent Event {get;set;}
    }
}