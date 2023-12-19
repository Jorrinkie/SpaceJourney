using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExploPressesShow : MonoBehaviour
{

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(PlayerPrefs.GetInt("Presses", 0).ToString());
    }
}
