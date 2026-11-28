using UnityEngine;

// Walks back and forth around where it starts. Touching it hurts the player;
// one shot destroys it. Its Rigidbody2D is Kinematic: it moves at the velocity
// it is given, and nothing pushes it around.
public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 2f;
    public AudioClip defeatSound;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;
    float startX;
    float direction = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startX = transform.position.x;
    }

    void Update()
    {
        // Turn around at either end of the patrol.
        if (transform.position.x > startX + distance)
        {
            direction = -1f;
        }
        else if (transform.position.x < startX - distance)
        {
            direction = 1f;
        }

        body.linearVelocity = new Vector2(direction * speed, 0f);

        // The art faces right; flip it when walking left.
        spriteRenderer.flipX = direction < 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.HitEnemy();
        }
        else if (other.GetComponent<Shot>() != null)
        {
            AudioSource.PlayClipAtPoint(defeatSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
