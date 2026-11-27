using UnityEngine;

// Shakes the camera for a moment. Call Shake() with how hard to shake.
// The curve sets how the shake fades: edit it in the Inspector.
public class CameraShake : MonoBehaviour
{
    public float duration = 0.3f;
    public AnimationCurve falloff = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

    Vector3 startPosition;
    float timer = 0f;
    float magnitude = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (timer > 0f)
        {
            // Unscaled time keeps the shake going during a hitstop.
            timer = timer - Time.unscaledDeltaTime;

            // 0 when the shake starts, 1 when it ends.
            float progress = 1f - timer / duration;
            float strength = magnitude * falloff.Evaluate(progress);

            Vector2 offset = Random.insideUnitCircle * strength;
            transform.position = startPosition + new Vector3(offset.x, offset.y, 0f);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public void Shake(float amount)
    {
        magnitude = amount;
        timer = duration;
    }
}
