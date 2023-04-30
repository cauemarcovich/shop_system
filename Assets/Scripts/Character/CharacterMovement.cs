using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Rigidbody2D rb;
    
    private Vector2 _movement;
    
    void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = _movement * speed;
    }
}
