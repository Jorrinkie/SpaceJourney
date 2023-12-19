using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBuy : MonoBehaviour
{
    public int maxhealth;
    public int cost;
    public int money;
    public TMP_Text costText;

    public Animator ButtonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        maxhealth = PlayerPrefs.GetInt("MaxHealth", 1);
        cost = 100 * maxhealth;
        costText.SetText(cost.ToString()+ "$");
    }

    // Update is called once per frame
    public void OnClick()
    {
        ButtonAnimator.SetTrigger("ButtonPress");
        maxhealth = PlayerPrefs.GetInt("MaxHealth", 1);
        cost = 100 * maxhealth;
        costText.SetText(cost.ToString()+ "$");
       money = PlayerPrefs.GetInt("Money", 0);
        if (money > cost)
        {
            money -= cost;
            PlayerPrefs.SetInt("Money", money);
            maxhealth++;
            PlayerPrefs.SetInt("MaxHealth", maxhealth);
            Debug.Log("Purchase hearth succesfull");
            //purchase sound
            maxhealth = PlayerPrefs.GetInt("MaxHealth", 1);
            cost = 100 * maxhealth;
            costText.SetText(cost.ToString() + "$");
        }
    }
}
