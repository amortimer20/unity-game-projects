using UnityEngine;

// Touching a checkpoint makes its spawn point the place the player comes back to,
// and raises its flag so the player can see the progress was saved.
public class Checkpoint : MonoBehaviour
{
    public Transform spawnPoint;
    public Sprite flagSprite;
    public AudioClip reachedSound;

    SpriteRenderer spriteRenderer;
    bool reached = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!reached && other.CompareTag("Player"))
        {
            reached = true;
            GameManager.instance.respawnPoint = spawnPoint;
            spriteRenderer.sprite = flagSprite;
            AudioSource.PlayClipAtPoint(reachedSound, Camera.main.transform.position);
        }
    }
}
