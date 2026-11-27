using UnityEngine;
using UnityEngine.InputSystem;

// Moves the ship left and right with A and D or the arrow keys.
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float edge = 8f;

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

        transform.position += new Vector3(direction, 0f, 0f) * speed * Time.deltaTime;

        // Stop at the edges of the screen.
        float x = Mathf.Clamp(transform.position.x, -edge, edge);
        transform.position = new Vector3(x, transform.position.y, 0f);
    }
}
