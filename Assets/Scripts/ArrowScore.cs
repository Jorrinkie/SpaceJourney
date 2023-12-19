using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ArrowScore : MonoBehaviour
{

    public arrowondeath arrowondeath;

    public float count;
    public float count2 = 270;
    public float speed = 0.05f;
    public float wobbleAmount = 10f; // Maximum wobble angle in degrees
    public float wobbleSpeed = 20f; // Wobble speed in degrees per second

    private float currentAngle = -270f; // Set the initial rotation angle
    private bool isWobbling = false;
    private int wobbleDirection = 1;
    public bool RunOnce = true;
    public ImageShake imageShake;



    // Start is called before the first frame update
    void Start()
    {
        arrowondeath = GameObject.Find("SpeedometerArrow").GetComponent<arrowondeath>();
        imageShake = GameObject.Find("Speedometer").GetComponent<ImageShake>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {



        count += speed;
        if (count < 270)
        {
            if (arrowondeath.stoprotate == false)
            {
                transform.Rotate(0, 0, -speed);
            }


        }
        
        else
        {

            if (arrowondeath.stoprotate == false)
            {
                if (RunOnce)
                {
                    RunOnce = false;
                    imageShake.StartShake();
                }
                if (!isWobbling)
                {
                    // Start wobbling in a random direction
                    wobbleDirection = Random.Range(0, 2) == 0 ? -1 : 1;
                    isWobbling = true;
                }

                // Calculate the new rotation angle
                currentAngle += wobbleDirection * wobbleSpeed * Time.deltaTime;

                // Clamp the rotation angle within the wobble range
                currentAngle = Mathf.Clamp(currentAngle, -270f - wobbleAmount, -270f + wobbleAmount);

                // Rotate the object
                transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

                // Check if the object has reached the limit of the wobble range
                if (Mathf.Approximately(currentAngle, -270f - wobbleAmount) || Mathf.Approximately(currentAngle, -270f + wobbleAmount))
                {
                    isWobbling = false;
                }
            }
        }

    }
}
