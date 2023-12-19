using UnityEngine;

public class randomSkin : MonoBehaviour
{
    public Sprite[] sprites; // An array to store the sprite options.

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if there are sprites in the array.
        if (sprites.Length > 0)
        {
            // Choose a random sprite from the array.
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
        else
        {
            Debug.LogError("No sprites assigned to the array.");
        }
    }
}
