using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arrowondeath : MonoBehaviour
{

    public float count2 = 270f;
    public DeathWait DeathWait;
    private bool isRotating = true;
    public bool stoprotate = false;

    public float rotationSpeed = 1.0f; // Adjust the speed of rotation

    // Start is called before the first frame update
    void Start()
    {
        DeathWait = GameObject.Find("Canvas").GetComponent<DeathWait>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DeathWait.deadwait == true)
        {
            stoprotate = true;

            Debug.Log("dead true");
            if (count2 > 0)
            {
                count2 -= 0.5f;

                if (isRotating)
                {
                    // Calculate the target rotation as Quaternion.identity (0 degrees rotation)
                    Quaternion targetRotation = Quaternion.identity;

                    // Use Quaternion.RotateTowards to smoothly rotate towards the target
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                    // Check if the rotation has reached the target
                    if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
                    {
                        // Set the rotation to exactly 0 degrees to ensure accuracy
                        transform.rotation = targetRotation;
                        isRotating = false;
                    }
                }
            }
        }
        
    }
}
