using UnityEngine;

// Flies down the screen. A laser destroys it; touching the player hurts the player.
public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int points = 10;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Gone past the bottom of the screen.
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Laser>() != null)
        {
            GameManager.instance.AddScore(points);
            GameManager.instance.Hitstop(0.05f);
            GameManager.instance.cameraShake.Shake(0.15f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.GetComponent<PlayerMovement>() != null)
        {
            GameManager.instance.LoseLife();
            GameManager.instance.Hitstop(0.2f);
            GameManager.instance.cameraShake.Shake(0.5f);
            Destroy(gameObject);
        }
    }
}
