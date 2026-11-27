using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Keeps the score and the clock. Any script can reach it as GameManager.instance.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int targetScore = 16;
    public float timeLeft = 20f;
    public bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Debug.Log("You have " + timeLeft + " seconds. Go!");
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetScene();
        }

        if (gameOver == false)
        {
            timeLeft = timeLeft - Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                gameOver = true;
                Debug.Log("Time's up! Score: " + score + ". Press R to play again.");
            }
        }
    }

    public void AddPoint()
    {
        if (gameOver == false)
        {
            score = score + 1;
            Debug.Log("Toppled! Score: " + score);

            if (score == targetScore)
            {
                gameOver = true;
                Debug.Log("You win with " + timeLeft.ToString("0.0") + " seconds left! Press R to play again.");
            }
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
