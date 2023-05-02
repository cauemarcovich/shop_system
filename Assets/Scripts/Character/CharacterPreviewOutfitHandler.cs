using Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class CharacterPreviewOutfitHandler : MonoBehaviour
    {
        [Header("SpriteLibrary References")]
        [SerializeField] private Image hairImage;
        [SerializeField] private Image bodyImage;
        [SerializeField] private Image pantsImage;

        public void SetPreviewOutfit(Item hair, Item body, Item pants)
        {
            SetSprite(hairImage, hair);
            SetSprite(bodyImage, body);
            SetSprite(pantsImage, pants);
        }

        private void SetSprite(Image image, Item item)
        {
            if (item != null)
            {
                image.enabled = true;
                image.sprite = item.GetFirstSprite();
            }
            else
            {
                image.enabled = false;
            }
        }
    }
}