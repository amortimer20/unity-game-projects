using UnityEngine;
using UnityEngine.InputSystem;

// Click anywhere to launch a ball from here toward the mouse.
public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public float launchPower = 15f;
    public float ballMass = 3f;
    public int ballsLeft = 3;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (ballsLeft > 0)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                mousePosition.z = 0f;
                Vector3 direction = (mousePosition - transform.position).normalized;

                GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                Rigidbody2D body = ball.GetComponent<Rigidbody2D>();
                body.mass = ballMass;
                body.linearVelocity = direction * launchPower;

                ballsLeft = ballsLeft - 1;
            }
            else
            {
                Debug.Log("Out of balls!");
            }
        }
    }
}
