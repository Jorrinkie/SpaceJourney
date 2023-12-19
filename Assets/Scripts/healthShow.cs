using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthShow : MonoBehaviour
{
    private int MaxHealth;
    public TMP_Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxHealth = PlayerPrefs.GetInt("MaxHealth", 1);
        HealthText.SetText(MaxHealth.ToString());
    }
}
