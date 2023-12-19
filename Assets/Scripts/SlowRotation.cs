using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SlowRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool randomspeed = true;
    public float flyspeed = -0.5f;
    public bool rotation = true;
    private void Start()
    {
        speed = 0.5f;
        if (randomspeed)
        {
            flyspeed = Random.Range(-0.4f, -1.5f);
        }
        
        gameObject.GetComponent<ConstantForce2D>().force = new Vector3(flyspeed, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (rotation)
        {
            transform.Rotate(0, 0, speed);
        }
    }


}
