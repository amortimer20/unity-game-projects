using UnityEngine;

// A crate scores one point the first time it is knocked out of place.
public class Crate : MonoBehaviour
{
    Vector3 startPosition;
    bool scored = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, startPosition);

        if (scored == false && distanceMoved > 1f)
        {
            scored = true;
            GameManager.instance.AddPoint();
        }
    }
}
