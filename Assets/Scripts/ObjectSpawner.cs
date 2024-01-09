using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Assign your prefab in the Inspector
    public float spawnRate;   // Rate at which objects spawn
    public float spawnDistance = 100.0f; // Distance from the right edge to spawn
    public bool increase;
    private float nextSpawnTime;
    public bool EnableChance = false;
    public bool StartAfter100 = false;
    private int chance;
    private bool run = false;
    public int Spawnchance;
    public GameObject Canvas;
    public HighScore HighScore;
    [SerializeField] private float Increase;
    [SerializeField] GameObject astroidParent;
    private void Start()
    {
        Spawnchance = PlayerPrefs.GetInt("SpawnChance", 90);
        nextSpawnTime = Time.time + spawnRate;
    }

    private void Update()
    {
        if (StartAfter100 == false)
        {


            if (increase)
            {
                if (Increase < 4.2)
                {
                    Increase = Increase + 0.1f * Time.deltaTime;
                }
            }


            if (Time.time >= nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnRate - Increase;
                run = true;

                if (EnableChance)
                {
                    if (run)
                    {
                        run = false;
                        chance = Random.Range(1, 100);
                        Debug.Log("SpawnChance number is: " + chance);
                        if (chance > Spawnchance)
                        {

                            SpawnObject();
                            chance = 0;
                            nextSpawnTime = Time.time + spawnRate - Increase;
                        }
                    }

                }
                else
                {


                    SpawnObject();

                }

            }
        }
        else
        {
            if (HighScore.start100Stage)
            {
                StartAfter100 = false;
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
