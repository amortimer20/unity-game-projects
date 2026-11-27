using UnityEngine;

// Spawns an enemy at a random spot along the top, a little faster each time.
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;
    public float minimumInterval = 0.4f;
    public float speedUp = 0.03f;
    public float width = 7.5f;

    float timer = 0f;

    void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer <= 0f)
        {
            float x = Random.Range(-width, width);
            Vector3 position = new Vector3(x, transform.position.y, 0f);
            Instantiate(enemyPrefab, position, Quaternion.identity);

            timer = spawnInterval;

            // Each enemy makes the next one come a little sooner.
            spawnInterval = Mathf.Max(minimumInterval, spawnInterval - speedUp);
        }
    }
}
