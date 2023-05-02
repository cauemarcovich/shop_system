using System.Collections;
using Dialogue;
using Events;
using UnityEngine;

namespace Character
{
    public class ShopKeeper : MonoBehaviour
    {
        [SerializeField] private float delayBeforeResetQuote; 
        
        [Header("Quotes")]
        [SerializeField] [TextArea] private string buyStandardQuote;
        [SerializeField] [TextArea] private string sellStandardQuote;
        [SerializeField] [TextArea] private string[] buyQuotes;  
        [SerializeField] [TextArea] private string[] sellQuotes;
        
        [Header("References")]
        [SerializeField] private CharacterOutfitHandler outfitHandler;

        private Coroutine _resetCoroutine;
        
        private void OnEnable()
        {
            EventManager.StartListening(ShopEvents.BUY_ITEM, SpeakBuyQuote);
            EventManager.StartListening(ShopEvents.SELL_ITEM, SpeakSellQuote);
            EventManager.StartListening(ShopEvents.CLOSE_BUY_SHOP, CancelReset);
            EventManager.StartListening(ShopEvents.CLOSE_SELL_SHOP, CancelReset);
        }
        
        private void OnDisable()
        {
            EventManager.StopListening(ShopEvents.BUY_ITEM, SpeakBuyQuote);
            EventManager.StopListening(ShopEvents.SELL_ITEM, SpeakSellQuote);
            EventManager.StartListening(ShopEvents.CLOSE_BUY_SHOP, CancelReset);
            EventManager.StartListening(ShopEvents.CLOSE_SELL_SHOP, CancelReset);
        }

        public void ShowBuyStore()
        {
            var dialogue = BuildShopDialogue(buyStandardQuote);
            
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
            EventManager.TriggerEvent(ShopEvents.OPEN_BUY_SHOP);
        }
        
        public void ShowSellStore()
        {
            var dialogue = BuildShopDialogue(sellStandardQuote);
            
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
            EventManager.TriggerEvent(ShopEvents.OPEN_SELL_SHOP);
        }

        public void SpeakBuyQuote(object item)
        {
            if (buyQuotes.Length == 0) return;

            var quote = buyQuotes[Random.Range(0, buyQuotes.Length)];
            var dialogue = BuildShopDialogue(quote);
            
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);

            CancelReset();
            _resetCoroutine = StartCoroutine(ResetQuote(buyStandardQuote));
        }
        
        public void SpeakSellQuote(object item)
        {
            if (sellQuotes.Length == 0) return;

            var quote = sellQuotes[Random.Range(0, sellQuotes.Length)];
            var dialogue = BuildShopDialogue(quote);
            
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);

            CancelReset();
            _resetCoroutine = StartCoroutine(ResetQuote(sellStandardQuote));
        }

        private void CancelReset()
        {
            if(_resetCoroutine != null)
                StopCoroutine(_resetCoroutine);
        }

        private IEnumerator ResetQuote(string quoteToReset)
        {
            Debug.Log("resetting");
            yield return new WaitForSeconds(delayBeforeResetQuote);
            
            Debug.Log("resetted");
            var dialogue = BuildShopDialogue(quoteToReset);
            EventManager.TriggerEvent(CharacterEvents.DIALOGUE_OPEN, dialogue);
        }
        
        private DialogueData BuildShopDialogue(string text) => new()
        {
            Text = text,
            CharacterOutfitHandler = outfitHandler,
            IsShopDialogue = true
        };
    }
}