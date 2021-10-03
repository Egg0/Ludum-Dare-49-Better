using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool debug;
    public float shakeDurationDebug;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    public float dampingSpeed = 1.0f;

    private bool randomShake;

    // The initial position of the GameObject
    Vector3 initialPosition;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && debug)
        {
            TriggerShake(shakeDurationDebug, shakeMagnitude, false);
        }

        if (shakeDuration > 0)
        {
            if (randomShake == true)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            } else
            {
                transform.localPosition = initialPosition + new Vector3(0, Random.Range(-1f, 1f), 0) * shakeMagnitude; // TODO: Make this fall off over time?
            }
            
            shakeDuration -= Time.unscaledDeltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float time, float magnitude, bool verticalOnly)
    {
        shakeDuration = time;
        shakeMagnitude = magnitude;
        randomShake = !verticalOnly;
    }
}
