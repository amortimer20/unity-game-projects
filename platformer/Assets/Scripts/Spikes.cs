using UnityEngine;

// Touching the spikes costs one health and sends the player back to the respawn point.
public class Spikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.HitHazard();
        }
    }
}
