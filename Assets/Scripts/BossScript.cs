using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public HighScore HighScore;
    public GameObject objectPrefab;
    public float spawnDistance = 100.0f;
    private int SpawnChance = 5;

    void Update()
    {
        if (HighScore.start300Stage)
        {
            SpawnChance = Random.Range(1, 10);
            if (SpawnChance == 8)
            {
                SpawnObject();
            }
        }
    }


    private void SpawnObject()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width + spawnDistance + 400.0f, Random.Range(0, Screen.height), Camera.main.nearClipPlane)
        );

        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        newObject.transform.parent = transform;
    }

}
