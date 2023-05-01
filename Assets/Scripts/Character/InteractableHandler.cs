using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class InteractableHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent onInteract;

        public void Interact()
        {
            onInteract.Invoke();
        }
    }
}
