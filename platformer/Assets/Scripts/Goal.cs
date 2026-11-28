using UnityEngine;

// Reaching the goal wins the level.
public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Win();
        }
    }
}
