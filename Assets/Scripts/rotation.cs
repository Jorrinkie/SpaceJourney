using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool MoveToRight = true;
        private void Start()
    {
        speed = Random.Range(0.1f, 0.8f);
        if (MoveToRight)
        {
            gameObject.GetComponent<ConstantForce2D>().force = new Vector3(Random.Range(-0.4f, -1.5f), 0, 0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

            transform.Rotate(0, 0, speed);

        
    }


}
