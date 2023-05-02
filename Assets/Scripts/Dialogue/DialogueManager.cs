using Character;
using Events;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private CharacterPreviewOutfitHandler characterPreviewOutfitHandler;

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
    }

    public class Dialogue
    {
        public CharacterOutfitHandler Character { get; set; }
        public string Text { get; set; }
        public bool IsShopDialogue { get; set; }
    }
}