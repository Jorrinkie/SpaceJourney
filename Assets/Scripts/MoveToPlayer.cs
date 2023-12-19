using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    public GameObject Player;
    public float timeToReachTarget = 100f;

    

    private void Start()
    {
        target = Player.transform.position;
        startPosition = transform.position;

        target = GameObject.Find("Player").transform.position;
        target.x -= 30f;




    }
    public void Update()
    {
        t += 0.2f * Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
        
    }



    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // destroy this object
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
