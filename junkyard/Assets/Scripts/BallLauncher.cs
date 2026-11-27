using UnityEngine;
using UnityEngine.InputSystem;

// Click anywhere to launch a ball from here toward the mouse.
// Block 2 explains every line. For now, add it and play.
public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0f;
            Vector3 direction = (mousePosition - transform.position).normalized;

            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().linearVelocity = direction * 15f;
        }
    }
}
