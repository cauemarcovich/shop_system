using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Animator))]
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int MoveUp = Animator.StringToHash("moveUp");
        private static readonly int MoveDown = Animator.StringToHash("moveDown");
        private static readonly int MoveLeft = Animator.StringToHash("moveLeft");
        private static readonly int MoveRight = Animator.StringToHash("moveRight");

        private int _currentAnimationHash;
    
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void UpdateAnimationWithDirection(Vector2 direction)
        {
            var animationHash = direction switch
            {
                _ when direction == Vector2.up => MoveUp,
                _ when direction == Vector2.down => MoveDown,
                _ when direction == Vector2.left => MoveLeft,
                _ when direction == Vector2.right => MoveRight,
                _ => MoveDown
            };

            if (animationHash != _currentAnimationHash)
            {
                _animator.SetTrigger(animationHash);
                _currentAnimationHash = animationHash;
            }
        }
    }
}