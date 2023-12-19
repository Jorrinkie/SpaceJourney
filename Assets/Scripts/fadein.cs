using UnityEngine;
using TMPro;
using System.Collections;

public class fadein : MonoBehaviour
{
    public float fadeInDuration = 2.0f; // Adjust this value to control the duration of the fade-in effect
    private TextMeshProUGUI textComponent;
    private float timer = 0.0f;
    private bool isFading = false;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0); // Start with zero alpha

        // Start the fade-in with a one-second delay
        StartCoroutine(StartFadeInWithDelay());
    }

    private IEnumerator StartFadeInWithDelay()
    {
        yield return new WaitForSeconds(1.0f); // Wait for one second

        StartFadeIn();
    }

    private void Update()
    {
        if (!isFading)
            return;

        timer += Time.deltaTime;

        if (timer < fadeInDuration)
        {
            // Calculate the alpha value based on the timer
            float alpha = timer / fadeInDuration;
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
        }
        else
        {
            // Ensure the alpha reaches 1.0f exactly and stop the fading
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1.0f);
            isFading = false;
        }
    }

    public void StartFadeIn()
    {
        isFading = true;
        timer = 0.0f;
    }
}
