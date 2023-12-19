using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgrounndscroller : MonoBehaviour
{
    public float Speed;

    private float offset;
    private Material mat;
    public bool SpeedUp = true;



    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        if (SpeedUp)
        {
            Speed += 0.1f * Time.deltaTime;
        }
        offset += (Time.deltaTime * Speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
