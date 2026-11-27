using UnityEngine;
using TMPro;

// Keeps the score and lives and shows them on screen.
// Any script can reach it as GameManager.instance.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject player;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateText();
    }

    public void AddScore(int points)
    {
        score = score + points;
        UpdateText();
    }

    public void LoseLife()
    {
        lives = lives - 1;
        UpdateText();

        if (lives <= 0)
        {
            Destroy(player);
        }
    }

    void UpdateText()
    {
        scoreText.text = "Score " + score;
        livesText.text = "x " + lives;
    }
}
