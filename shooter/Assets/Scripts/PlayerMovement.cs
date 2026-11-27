using UnityEngine;
using UnityEngine.InputSystem;

// Moves the ship left and right with A and D or the arrow keys.
// Its speed eases toward the target instead of jumping straight to it.
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float edge = 8f;
    public float smoothing = 12f;

    float velocity = 0f;

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

        // Lerp moves velocity part of the way to the target speed each frame.
        float targetVelocity = direction * speed;
        velocity = Mathf.Lerp(velocity, targetVelocity, smoothing * Time.deltaTime);
        transform.position += new Vector3(velocity, 0f, 0f) * Time.deltaTime;

        // Stop at the edges of the screen.
        float x = Mathf.Clamp(transform.position.x, -edge, edge);
        transform.position = new Vector3(x, transform.position.y, 0f);
    }
}
