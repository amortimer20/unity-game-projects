using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

// The two states the game can be in. It is always exactly one of them.
public enum GameState
{
    Playing,
    GameOver
}

// Keeps the player's health and the game state, and shows them on screen.
// Any script can reach it as GameManager.instance.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state = GameState.Playing;
    public int health = 3;
    public TMP_Text healthText;
    public GameObject gameOverText;
    public Rigidbody2D player;
    public Transform respawnPoint;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateText();
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (state == GameState.GameOver && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Hazards call this: lose one health and go back to the respawn point.
    public void HitHazard()
    {
        if (state != GameState.Playing)
        {
            return;
        }

        LoseHealth();

        if (state == GameState.Playing)
        {
            // The player is a dynamic body, so move the body, not the transform.
            player.position = respawnPoint.position;
            player.linearVelocity = Vector2.zero;
        }
    }

    public void LoseHealth()
    {
        health = health - 1;
        UpdateText();

        if (health <= 0)
        {
            state = GameState.GameOver;
            player.gameObject.SetActive(false);
            gameOverText.SetActive(true);
        }
    }

    void UpdateText()
    {
        healthText.text = "Health " + health;
    }
}
