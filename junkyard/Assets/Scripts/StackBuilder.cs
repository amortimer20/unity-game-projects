using UnityEngine;

// Builds a new random stack at the start of every round, one column at a time.
public class StackBuilder : MonoBehaviour
{
    public GameObject[] cratePrefabs;
    public int columns = 4;
    public int minHeight = 2;
    public int maxHeight = 5;

    void Start()
    {
        int count = 0;

        for (int column = 0; column < columns; column++)
        {
            int height = Random.Range(minHeight, maxHeight + 1);

            for (int row = 0; row < height; row++)
            {
                GameObject prefab = cratePrefabs[Random.Range(0, cratePrefabs.Length)];
                Vector3 position = transform.position + new Vector3(column, row, 0f);
                Instantiate(prefab, position, Quaternion.identity);
                count = count + 1;
            }
        }

        GameManager.instance.targetScore = count;
        Debug.Log("Topple all " + count + " crates!");
    }
}
