using UnityEngine;
using UnityEngine.InputSystem;

// Fires a Shot the way the player is facing when J is pressed.
public class PlayerShooting : MonoBehaviour
{
    public GameObject shotPrefab;

    PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            // Start the shot just in front of the player, on the side it faces.
            Vector3 offset = new Vector3(movement.facing * 0.6f, 0.1f, 0f);
            GameObject shot = Instantiate(shotPrefab, transform.position + offset, Quaternion.identity);
            shot.GetComponent<Shot>().direction = movement.facing;
        }
    }
}
