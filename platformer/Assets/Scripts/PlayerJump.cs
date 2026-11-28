using UnityEngine;
using UnityEngine.InputSystem;

// Jumps on Space, but only while standing on something on the Ground layer.
public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 7f;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Is there any Ground collider inside a small circle at the feet?
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (grounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Keep the sideways speed and give it an upward one. Gravity does the rest.
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpSpeed);
        }
    }
}
