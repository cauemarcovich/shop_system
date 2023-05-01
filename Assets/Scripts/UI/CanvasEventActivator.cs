using Events;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasEventActivator : MonoBehaviour
    {
        [SerializeField] private GameEvents showEvent;
        [SerializeField] private GameEvents hideEvent;
    
        private Canvas _canvas;

        private void Awake() => _canvas = GetComponent<Canvas>();

        private void OnEnable()
        {
            EventManager.StartListening(showEvent, Show);
            EventManager.StartListening(showEvent, ShowAlt);
            EventManager.StartListening(hideEvent, Hide);
            EventManager.StartListening(hideEvent, HideAlt);
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(showEvent, Show);
            EventManager.StopListening(showEvent, ShowAlt);
            EventManager.StopListening(hideEvent, Hide);
            EventManager.StopListening(hideEvent, HideAlt);
        }

        public void Show() => _canvas.enabled = true;
        public void ShowAlt(object obj) => _canvas.enabled = true;
        public void Hide() => _canvas.enabled = false;
        public void HideAlt(object obj) => _canvas.enabled = false;
    }
}
