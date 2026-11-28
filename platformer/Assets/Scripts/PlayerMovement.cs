using UnityEngine;
using UnityEngine.InputSystem;

// Runs left and right with A and D or the arrow keys.
// Physics moves the body; this script only tells it how fast to go sideways.
public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float facing = 1f;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            direction = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            direction = 1f;
        }

        // Remember which way the player last pressed: 1 is right, -1 is left.
        if (direction != 0f)
        {
            facing = direction;
        }

        // Set the sideways speed and keep whatever vertical speed gravity has given it.
        body.linearVelocity = new Vector2(direction * speed, body.linearVelocity.y);
    }
}
