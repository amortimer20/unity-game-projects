using UnityEngine;

// Tells the Animator what the player is doing, so it can pick the right clip,
// and flips the sprite to face the way the player last moved.
public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;
    SpriteRenderer spriteRenderer;
    PlayerMovement movement;
    PlayerJump jump;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(body.linearVelocity.x));
        animator.SetBool("grounded", jump.grounded);
        animator.SetFloat("yVelocity", body.linearVelocity.y);

        // The art faces right; flip it when facing left.
        spriteRenderer.flipX = movement.facing < 0f;
    }
}
