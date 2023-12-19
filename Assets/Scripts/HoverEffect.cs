using UnityEngine;
using UnityEngine.UI;

public class HoverEffect : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public float hoverAmplitude = 30f;  // Adjust this to control the height of the hover.
    public float hoverSpeed = 2.0f;     // Adjust this to control the speed of the hover.

    private float initialY;

    private void Start()
    {
        if (targetRectTransform == null)
        {
            Debug.Log("Target RectTransform not assigned. Please assign it in the Inspector.");
            enabled = false;
            return;
        }

        initialY = targetRectTransform.anchoredPosition.y;
    }

    private void Update()
    {
        float newY = initialY + Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        targetRectTransform.anchoredPosition = new Vector2(targetRectTransform.anchoredPosition.x, newY);
    }
}
