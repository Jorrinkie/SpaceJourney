using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldChanceShow : MonoBehaviour
{
    private int GoldChance;
    public TMP_Text ChanceText;
    private int ChanceReverse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldChance = PlayerPrefs.GetInt("GoldChance", 90);
        ChanceReverse = 110 - GoldChance;
        ChanceText.SetText(ChanceReverse.ToString() + "%");
    }
}
