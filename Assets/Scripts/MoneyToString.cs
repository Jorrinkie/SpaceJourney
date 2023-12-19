using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyToString : MonoBehaviour
{

    public TMP_Text Moneyy; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Moneyy.SetText(PlayerPrefs.GetInt("Money", 0).ToString() + "$");
    }
}
