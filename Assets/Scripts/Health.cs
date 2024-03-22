using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{

    private int maxHealth;
    public int health;
    public TMP_Text text;
    public DeathWait deathwait;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        deathwait = GameObject.Find("Canvas").GetComponent<DeathWait>();
        maxHealth = PlayerPrefs.GetInt("MaxHealth", 1);
       health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      text.SetText(health.ToString());

        if (health < 1)
        {
            deathwait.deadwait = true;
            Destroy(player);
        }
    }
    public void OnclickHack()
    {
        health = 100;
    }
}
