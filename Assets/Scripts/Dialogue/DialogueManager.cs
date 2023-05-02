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

        public void ShowDialogue(object text) => ShowDialogue((Dialogue)text);

        public void ShowDialogue(Dialogue dialogue)
        {
            ChangeAnchors(dialogue.IsShopDialogue);

            characterPreviewOutfitHandler.SetPreviewOutfit(dialogue.Character.Hair, dialogue.Character.Body,
                dialogue.Character.Pants);
            textMesh.text = dialogue.Text;
        }

        private void ChangeAnchors(bool isShopDialogue)
        {
            var minAnchor = _rect.anchorMin;
            minAnchor.x = isShopDialogue ? shopMinXAnchor : 0f;
            _rect.anchorMin = minAnchor;
        }

        private void ManageButtons(UnityEvent button1Event, UnityEvent button2Event)
        {
            if (button1Event != null)
            {
                button1.gameObject.SetActive(true);
                button1.onClick.AddListener(button1Event.Invoke);
            }
            else
            {
                button1.gameObject.SetActive(false);
            }
            
            if (button2Event != null)
            {
                button2.gameObject.SetActive(true);
                button2.onClick.AddListener(button2Event.Invoke);
            }
            else
            {
                button1.gameObject.SetActive(false);
            }
        }
    }

    public class Dialogue
    {
        public CharacterOutfitHandler Character { get; set; }
        public string Text { get; set; }
        public bool IsShopDialogue { get; set; }
        public UnityEvent Button1Event { get; set; }
        public UnityEvent Button2Event { get; set; }
    }
}