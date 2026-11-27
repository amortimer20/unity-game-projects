using UnityEngine;
using UnityEngine.InputSystem;

// Fires a laser from the nose of the ship each time Space is pressed.
public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;
    public AudioClip shootSound;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && GameManager.instance.state == GameState.Playing)
        {
            Vector3 nose = transform.position + new Vector3(0f, 0.6f, 0f);
            Instantiate(laserPrefab, nose, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        }
    }
}
