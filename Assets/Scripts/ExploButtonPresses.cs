using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExploButtonPresses : MonoBehaviour
{
    public int presses;
    public int cost;
    public int money;
    public TMP_Text costText;

    private Animator ButtonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        presses = PlayerPrefs.GetInt("Presses", 0);
        cost = 500 * (1 + presses);
        costText.SetText(cost.ToString() + "$");
    }

    // Update is called once per frame
    public void OnClick()
    {
        ButtonAnimator.SetTrigger("ButtonPress");
        presses = PlayerPrefs.GetInt("Presses", 0);
        cost = 500 * (1 + presses);
        costText.SetText(cost.ToString() + "$");
        money = PlayerPrefs.GetInt("Money", 0);
        if (money > cost)
        {
            money -= cost;
            PlayerPrefs.SetInt("Money", money);
            presses++;
            PlayerPrefs.SetInt("Presses", presses);
            Debug.Log("Purchase Explo succesfull");
            //purchase sound
            presses = PlayerPrefs.GetInt("Presses", 0);
            cost = 500 * (1 + presses);
            costText.SetText(cost.ToString() + "$");
        }
    }
}
