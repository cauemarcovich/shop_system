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
            EventManager.StartListening(hideEvent, Hide);
        }
    
        private void OnDisable()
        {
            EventManager.StopListening(showEvent, Show);
            EventManager.StopListening(hideEvent, Hide);
        }

        public void Show() => _canvas.enabled = true;
        public void Hide() => _canvas.enabled = false;
    }
}
