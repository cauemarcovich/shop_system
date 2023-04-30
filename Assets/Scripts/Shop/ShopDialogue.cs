using System.Collections;
using Events;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ShopDialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private float resetSpeakDelay = 3f;

        private Coroutine _greetingsCoroutine;
    
        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.BUY_ITEM, ShowGreetings);
        }

        private void OnDisable()
        {
            EventManager.StartListening(ShopEvents.BUY_ITEM, ShowGreetings);
        }

        private void ShowGreetings(object item)
        {
            if(_greetingsCoroutine != null)
                StopCoroutine(_greetingsCoroutine);
            _greetingsCoroutine = StartCoroutine(ShowGreetingsRoutine());
        }

        private IEnumerator ShowGreetingsRoutine()
        {
            var oldPhrase = textMesh.text;
        
            textMesh.text = "Thank you for buying in the great shop of wonderful things.";
            yield return new WaitForSeconds(resetSpeakDelay);
        
            textMesh.text = oldPhrase;
        }
    }
}