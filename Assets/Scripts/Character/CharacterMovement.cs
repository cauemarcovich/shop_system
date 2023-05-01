using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AnimationHandler animationHandler;

        private Vector2 _moveDirection;
        public Vector2 MoveDirection => _moveDirection;

        public void SetMovement(Vector2 movement)
        {
            rb.velocity = movement * speed;

            SetDirection(movement);
        }

        private void SetDirection(Vector2 movement)
        {
            if (movement.magnitude < 0.1f) return;
            
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0f) _moveDirection = Vector2.right;
                else _moveDirection = Vector2.left;
            }
            else
            {
                if (movement.y > 0f) _moveDirection = Vector2.up;
                else _moveDirection = Vector2.down;
            }

            animationHandler.UpdateAnimationWithDirection(_moveDirection);
        }
    }
}