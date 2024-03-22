using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemovement : MonoBehaviour
{

    public bool RunOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && RunOnce)
        {
            RunOnce = false;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            RunOnce = true;
            


        }
    }
}
