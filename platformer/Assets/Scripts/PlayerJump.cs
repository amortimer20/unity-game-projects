using UnityEngine;
using UnityEngine.InputSystem;

// Jumps on Space, but only while standing on something on the Ground layer.
// The arc is shaped by two gravities: a lighter one on the way up and a heavier
// one on the way down, so the jump rises with weight and lands quickly.
// Letting go of Space early cuts the rise short: tap for a hop, hold for a full jump.
public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 12f;
    public float riseGravity = 3f;
    public float fallGravity = 5f;
    public float maxFallSpeed = 15f;
    public float jumpCut = 0.5f;
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

        // Space let go while still rising: keep only part of the upward speed.
        if (Keyboard.current.spaceKey.wasReleasedThisFrame && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * jumpCut);
        }

        // Rising or falling? Pick the gravity for that half of the arc.
        if (body.linearVelocity.y > 0f)
        {
            body.gravityScale = riseGravity;
        }
        else
        {
            body.gravityScale = fallGravity;
        }

        // Never fall faster than maxFallSpeed.
        if (body.linearVelocity.y < -maxFallSpeed)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, -maxFallSpeed);
        }
    }
}
