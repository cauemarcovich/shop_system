using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;

        public MoveDirection _moveDirection;

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
                if (movement.x > 0f) _moveDirection = MoveDirection.Right;
                else _moveDirection = MoveDirection.Left;
            }
            else
            {
                if (movement.y > 0f) _moveDirection = MoveDirection.Up;
                else _moveDirection = MoveDirection.Down;
            }
        }
    }

    public enum MoveDirection
    {
        Up,
        Right,
        Down,
        Left
    }
}