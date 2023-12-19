using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldChanceBuy : MonoBehaviour
{
    public int Chance;
    public int cost;
    public int money;
    public int BoughtTimes;
    public TMP_Text costText;



    private Animator ButtonAnimator;


    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        Chance = PlayerPrefs.GetInt("GoldChance", 90);
        BoughtTimes = PlayerPrefs.GetInt("BoughtGoldAstroid", 1);
        cost = 100 * BoughtTimes;
        costText.SetText(cost.ToString() + "$");
    }

    // Update is called once per frame
    public void OnClick()
    {
        

        if (BoughtTimes < 9) {
        ButtonAnimator.SetTrigger("ButtonPress");
        Chance = PlayerPrefs.GetInt("GoldChance", 90);
        cost = 100 * BoughtTimes;
        costText.SetText(cost.ToString() + "$");
        money = PlayerPrefs.GetInt("Money", 0);
            if (money > cost)
            {
                money -= cost;
                PlayerPrefs.SetInt("Money", money);
                Chance -= 10;
                BoughtTimes++;
                PlayerPrefs.SetInt("BoughtGoldAstroid", BoughtTimes);
                PlayerPrefs.SetInt("GoldChance", Chance);
                Debug.Log("Purchase GoldChance succesfull");
                //purchase sound
                Chance = PlayerPrefs.GetInt("GoldChance", 90);
                cost = 100 * BoughtTimes;
                costText.SetText(cost.ToString() + "$");
            }
            else
            {
                //error sound, lowest chance reached
            }
        }
    }
}
