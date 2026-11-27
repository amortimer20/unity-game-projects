using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

// The three states the game can be in. It is always exactly one of them.
public enum GameState
{
    Title,
    Playing,
    GameOver
}

// Keeps the score, lives and game state, and shows them on screen.
// Any script can reach it as GameManager.instance.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state = GameState.Title;
    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject titleText;
    public GameObject gameOverText;
    public GameObject player;
    public CameraShake cameraShake;

    float hitstopTimer = 0f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateText();
        titleText.SetActive(true);
        gameOverText.SetActive(false);
    }

    void Update()
    {
        // Count the hitstop down in real time, then let the game run again.
        if (hitstopTimer > 0f)
        {
            hitstopTimer = hitstopTimer - Time.unscaledDeltaTime;

            if (hitstopTimer <= 0f)
            {
                Time.timeScale = 1f;
            }
        }

        if (state == GameState.Title && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            state = GameState.Playing;
            titleText.SetActive(false);
        }
        else if (state == GameState.GameOver && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
            state = GameState.GameOver;
            Destroy(player);
            gameOverText.SetActive(true);
        }
    }

    // Freezes the game for a split second so a hit lands with weight.
    public void Hitstop(float seconds)
    {
        hitstopTimer = seconds;
        Time.timeScale = 0f;
    }

    void UpdateText()
    {
        scoreText.text = "Score " + score;
        livesText.text = "x " + lives;
    }
}
