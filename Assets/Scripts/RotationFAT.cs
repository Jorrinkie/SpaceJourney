using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class RotationFAT : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        speed = Random.Range(0.1f, 0.4f);
        gameObject.GetComponent<ConstantForce2D>().force = new Vector3(Random.Range(-0.4f, -0.8f), 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed);
      //  gameObject.GetComponent<ConstantForce2D>().force = new Vector3(0, 0, 0);
    }


}
