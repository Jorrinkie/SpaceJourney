using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{

    public DeathWait deathwait;
    public Health health;
    public GameObject Particles;
    public ImageShake imageShake;
    public ScreenShake screenShake;
    public InfoGiver info;

    private void Start()
    {
        //OLD CODE:
        //deathwait = GameObject.Find("Canvas").GetComponent<DeathWait>();
        //health = GameObject.Find("Lives").GetComponent<Health>();
        //screenShake = GameObject.Find("Main Camera").GetComponent<ScreenShake>();

        //NEW CODE:
        info = transform.parent.parent.GetComponent<InfoGiver>();
        
        deathwait = info.Canvas.GetComponent<DeathWait>();
        health = info.Lives.GetComponent<Health>();
        screenShake = info.MainCamera.GetComponent<ScreenShake>();

    }
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                // destroy this object
          //      Destroy(collision.gameObject);
            // deathwait.deadwait = true;
                 health.health--;

                  screenShake.StartShake(0.2f, 0.3f);
                  Debug.Log(health.health);
                Instantiate(Particles,transform.position, Quaternion.identity);
                Destroy(this.gameObject);
               
            }
        }


}
