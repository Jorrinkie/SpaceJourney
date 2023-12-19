using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Transform mainCamera;
    private Vector3 initialCameraPosition;
    private float shakeDuration = 0.2f;
    private float shakeIntensity = 1f;

    private void Start()
    {
        mainCamera = Camera.main.transform;
        initialCameraPosition = mainCamera.position;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            // Generate a random offset within the specified intensity.
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;

            // Apply the offset to the camera's position.
            mainCamera.position = initialCameraPosition + randomOffset;

            // Decrement the shake duration.
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // Reset the camera's position when the shake duration is over.
            mainCamera.position = initialCameraPosition;
        }
    }

    // Call this method to start the screen shake.
    public void StartShake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
