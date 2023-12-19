using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] HighScore HighScore;

    public void addscore(int amount)
    {
        HighScore.TimeF += amount;
        Debug.Log("Coin!");
    }

}
