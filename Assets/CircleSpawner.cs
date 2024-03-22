using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public int NumOfCircles = 1;
    public int NumOfObjects = 1;

    public float RadiusSize = 15f;

    public Transform parentTransform;
    public GameObject prefab;

    List<GameObject> spawnedGo = new List<GameObject>();
    int NumOfCirclesLast = 0;

    private void Awake()
    {
        NumOfCirclesLast = NumOfCircles;
    }

    private void Start()
    {
        SpawnNew();
        StartCoroutine(Animation());
    }

    private void Update()
    {
        if (NumOfCircles != NumOfCirclesLast)
            SpawnNew();
    }

    void SpawnNew()
    {
        foreach (var item in spawnedGo)
        {
            Destroy(item);
        }

        Vector3 center = transform.position;
        center.y = 0;

        for (int i = 0; i <= NumOfCircles; i++)
        {
            for (int j = 0; j < NumOfObjects; j++)
            {

                int a = 360 / NumOfObjects * j;
                Vector3 pos = RandomCircle(center, RadiusSize * i, a);
                GameObject newGo = Instantiate(prefab, pos, Quaternion.identity, parentTransform);

                spawnedGo.Add(newGo);
            }
            NumOfCirclesLast = NumOfCircles;
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.y;
        return pos;
    }


    IEnumerator Animation()
    {
        yield return new WaitForSeconds(5f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.1f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.1f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.1f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.1f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles += 1;
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(0.2f);
        NumOfCircles -= 1;
        yield return new WaitForSeconds(2f);
        NumOfCircles += 1;
    }

}
