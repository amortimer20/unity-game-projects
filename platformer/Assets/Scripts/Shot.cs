using UnityEngine;

// Flies sideways in the direction it was fired, and disappears when it hits
// the level or after a short time. Like the player, it is moved by physics:
// its Rigidbody2D gets a velocity once and has gravity scale 0.
public class Shot : MonoBehaviour
{
    public float speed = 14f;
    public float lifetime = 1f;
    public float direction = 1f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction * speed, 0f);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
