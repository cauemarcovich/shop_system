using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]private float speed;
        [SerializeField]private Rigidbody2D rb;
    
        public void SetMovement(Vector2 movement)
        {
            rb.velocity = movement * speed;
        }
    }
}
