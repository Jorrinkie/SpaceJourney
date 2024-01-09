using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointrigger : MonoBehaviour
{
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventManager.current.CoinPickUp();
            Debug.Log("Coin!");
            Destroy(this.gameObject);
        }
    }

}
