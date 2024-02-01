using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private int RandomWait;
    [SerializeField] private int RandomYValue;
    [SerializeField] Vector3 NewPosition;
    [SerializeField] private Vector3 Oldpos;
    [SerializeField] private float Duration = 3f;
    [SerializeField] private float TimePassed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimePassed += Time.deltaTime;
        float percantagecomplete = TimePassed / Duration;

        if (Timer > RandomWait)
        {
            RandomWait = Random.Range(8, 16);
            Timer = 0;
            RandomYValue = Random.Range(-4, 5);
            NewPosition = new Vector3(6, RandomYValue, -9.8f);
            Oldpos = transform.position;

            TimePassed = 0;
        }
        transform.position = Vector3.Lerp(Oldpos, NewPosition, Mathf.SmoothStep(0, 1, percantagecomplete));
    }
}
