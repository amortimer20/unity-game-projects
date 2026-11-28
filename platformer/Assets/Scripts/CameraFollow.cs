using UnityEngine;

// Follows the target smoothly, but never shows past the level's edges.
// The limits are the lowest and highest positions the camera itself may take.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public float minX = 0f;
    public float maxX = 50f;
    public float minY = 0f;
    public float maxY = 4f;

    // LateUpdate runs after every Update, once the player has moved this frame.
    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        float x = Mathf.Clamp(target.position.x, minX, maxX);
        float y = Mathf.Clamp(target.position.y, minY, maxY);
        Vector3 goal = new Vector3(x, y, transform.position.z);

        // Lerp moves the camera part of the way to the goal each frame.
        transform.position = Vector3.Lerp(transform.position, goal, smoothing * Time.deltaTime);
    }
}
