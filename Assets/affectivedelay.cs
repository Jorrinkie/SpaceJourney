using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affectivedelay : MonoBehaviour
{
    public SpriteRenderer sprite;
    public CircleCollider2D collision;
    public InfoGiver info;
    // Start is called before the first frame update
    void Start()
    {
        collision = transform.GetComponent<CircleCollider2D>();
        collision.enabled = false;
        sprite.color = new Color(1, 0, 0, 1);
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Delay());
        info = transform.parent.parent.GetComponent<InfoGiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (info.CircleSpawner.activeSelf == false)
        {
           Destroy(gameObject);
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        collision.enabled = true;
        sprite.color = new Color(1, 1, 1, 1);

    }
}
