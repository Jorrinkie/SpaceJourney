using UnityEngine;
using UnityEngine.UI;

public class ImageShake : MonoBehaviour
{
    public Image imageToShake; // Reference to the Image component you want to shake.
    public float shakeDuration = 0.5f; // Duration of the shake animation.
    public float shakeIntensity = 0.2f; // Intensity of the shake.

    private Vector3 initialPosition;
    private float shakeTimer = 0f;

    private void Start()
    {
        initialPosition = imageToShake.rectTransform.localPosition;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            // Shake the image by adding a random offset to its position.
            Vector2 randomOffset = Random.insideUnitCircle * shakeIntensity;
            imageToShake.rectTransform.localPosition = initialPosition + (Vector3)randomOffset;

            // Decrement the timer.
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the image position when the shake timer is finished.
            imageToShake.rectTransform.localPosition = initialPosition;
        }
    }

    // Call this method to start the shake animation.
    public void StartShake()
    {
        shakeTimer = shakeDuration;
    }
}
