using UnityEngine;
using UnityEngine.InputSystem;

// Jumps on Space, but only while standing on something on the Ground layer.
// The arc is shaped by two gravities: a lighter one on the way up and a heavier
// one on the way down, so the jump rises with weight and lands quickly.
// Letting go of Space early cuts the rise short: tap for a hop, hold for a full jump.
// Two timers forgive the player's timing:
//   coyote time - a jump still works for a moment after running off a ledge;
//   jump buffer - a jump pressed just before landing happens when the feet touch down.
public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 12f;
    public float riseGravity = 3f;
    public float fallGravity = 5f;
    public float maxFallSpeed = 15f;
    public float jumpCut = 0.5f;
    public float coyoteTime = 0.1f;
    public float bufferTime = 0.1f;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D body;
    float coyoteTimer = 0f;
    float bufferTimer = 0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Is there any Ground collider inside a small circle at the feet?
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Standing refills the coyote timer; in the air it runs down.
        if (grounded)
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer = coyoteTimer - Time.deltaTime;
        }

        // A press fills the buffer timer; otherwise it runs down.
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            bufferTimer = bufferTime;
        }
        else
        {
            bufferTimer = bufferTimer - Time.deltaTime;
        }

        // A recent press and a recent floor: jump, and empty both timers.
        if (bufferTimer > 0f && coyoteTimer > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpSpeed);
            bufferTimer = 0f;
            coyoteTimer = 0f;
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
