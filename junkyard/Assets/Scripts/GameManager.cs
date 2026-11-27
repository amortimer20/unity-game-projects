using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetScene();
        }
    }

    public void AddPoint()
    {
        score = score + 1;
        Debug.Log("Toppled! Score: " + score);

        if (score == targetScore)
        {
            Debug.Log("You win! Press R to play again.");
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
