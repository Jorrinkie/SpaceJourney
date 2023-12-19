using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killwhentouched : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite Rock1;
    public Sprite Rock2;
    public Sprite Rock3;
    public Sprite Rock4;
    public int Hits = 6;
    public float fadeDuration = 0.1f; // Duration in seconds for fading out.

    private bool isFading = false;

    public PauseMenu Pausemenu;

    void Start()
    {
        
    }

    void Update()
    {
        
   
        
    }

    void OnMouseDown()
    {

            Hits--;
            if (Hits == 4)
            {
                SpriteRenderer.sprite = Rock2;
            }
            if (Hits == 2)
            {
                SpriteRenderer.sprite = Rock3;
            }
            if (Hits < 1 && !isFading)
            {
                StartCoroutine(FadeOutAndDestroy());
            }
        
    }
    IEnumerator FadeOutAndDestroy()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color initialColor = SpriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SpriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is fully transparent and then destroy it.
        SpriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
        Destroy(gameObject);
    }
}
