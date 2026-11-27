using UnityEngine;

// Flies straight up, then removes itself once it is well off the screen.
public class Laser : MonoBehaviour
{
    public float speed = 12f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
