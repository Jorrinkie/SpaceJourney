using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Explotion : MonoBehaviour
{

    public LayerMask ignoredLayers;
    public GameObject EXPLO;
    public int SplashRange = 50;
    public float fadeDuration = 1.0f; // Duration of the fade effect.
    public int Presses;
    public GameObject EXPLObutton;

    private void Start()
    {
        Presses = PlayerPrefs.GetInt("Presses", 0);
    }

    private void Update()
    {
        if (Presses < 1)
        {
            EXPLObutton.SetActive(false);
        }
    }

    // Start is called before the first frame update
    public void OnExplosion()

    {
        if (Presses > 0)
        {
            Presses--;
            Instantiate(EXPLO, transform.position, Quaternion.identity);
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject != gameObject && !IsIgnoredLayer(hitCollider.gameObject))
                {
                    StartCoroutine(FadeObject(hitCollider.gameObject));
                }
            }
        }
        else
        {
            EXPLObutton.SetActive(false);
        }
    }

    bool IsIgnoredLayer(GameObject obj)
    {
        int objLayer = obj.layer;
        return ignoredLayers == (ignoredLayers | (1 << objLayer));
    }

    IEnumerator FadeObject(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            // If the object doesn't have a SpriteRenderer component, skip fading.
            Destroy(obj);
            yield break;
        }

        float startTime = Time.time;
        Color startColor = renderer.color;

        while (Time.time < startTime + fadeDuration && obj != null) 
        {
            float t = (Time.time - startTime) / fadeDuration;
            renderer.color = Color.Lerp(startColor, Color.clear, t);
            yield return null;
        }

        if (obj != null)
        {
            Destroy(obj); // Destroy the object after it has faded out.
        }
    }
}
