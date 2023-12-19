using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject ObjectSpawn;
    public float time;

    void Update()
    {
        time += Time.deltaTime;

        if (time > 5) 
        {
            time = 0;
            Instantiate(ObjectSpawn);
        }
    }
}
