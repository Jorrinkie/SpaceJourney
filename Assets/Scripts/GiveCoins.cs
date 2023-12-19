using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCoins : MonoBehaviour
{

    public HighScore Highscore;
    private bool RunOnce = true;
    public int Coinworth = 2;
    // Start is called before the first frame update
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (RunOnce)
            {
                RunOnce = false;
                Highscore = GameObject.Find("Canvas").GetComponent<HighScore>();
                Highscore.TimeF += Coinworth;

                Debug.Log("Coin!");
                Destroy(this.gameObject);
            }
        }
    }
}
