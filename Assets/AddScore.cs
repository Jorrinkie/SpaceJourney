using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : PlayerController
{

    public int Coinworth = 2;
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            addscore(Coinworth);
            Destroy(this.gameObject);
        }
    }
}

