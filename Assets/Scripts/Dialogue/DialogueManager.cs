using Character;
using Events;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
    
        [Header("Anchors")]
        [SerializeField] private Vector2 normalDialogueAnchors;
        [SerializeField] private Vector2 shopDialogueAnchors;

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

            textMesh.text = dialogue.Text;
        }

        private void ChangeAnchors(bool isShopDialogue)
        {
            var minAnchor = _rect.anchorMin;
            var maxAnchor = _rect.anchorMax;
        
            minAnchor.x = isShopDialogue ? shopDialogueAnchors.x : normalDialogueAnchors.x;
            maxAnchor.x = isShopDialogue ? shopDialogueAnchors.y : normalDialogueAnchors.y;

            _rect.anchorMin = minAnchor;
            _rect.anchorMax = maxAnchor;
        }
    }

    public class Dialogue
    {
        public CharacterOutfitHandler Character { get; set; }
        public string Text { get; set; }
        public bool IsShopDialogue { get; set; }
    }
}