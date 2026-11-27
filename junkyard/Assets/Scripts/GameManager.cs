using UnityEngine;

// Keeps the score. Any script can reach it as GameManager.instance.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int targetScore = 16;

    void Awake()
    {
        instance = this;
    }
}
