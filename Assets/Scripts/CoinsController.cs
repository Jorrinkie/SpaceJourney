using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public HighScore Highscore;
    public int Coinworth = 2;
    private void Start()
    {
        EventManager.current.OnCoinPickUp += Addscore;
    }

    private void Addscore()
    {
        //add the score needed
        Highscore = GameObject.Find("Canvas").GetComponent<HighScore>();
        Highscore.TimeF += Coinworth;
    }
}
