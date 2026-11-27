using UnityEngine;

// Flies down the screen. A laser destroys it; touching the player hurts the player.
public class Enemy : MonoBehaviour
{
    public float speed = 3f;

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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("The player was hit!");
            Destroy(gameObject);
        }
    }
}
