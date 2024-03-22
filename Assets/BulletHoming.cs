using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : MonoBehaviour
{

    [SerializeField] private float Duration = 3f;
    [SerializeField] private float TimePassed;
    [SerializeField] Vector3 NewPosition;
    [SerializeField] private Vector3 NewVelocity;
    [SerializeField] private GameObject Player;
    public InfoGiver info;

    // Start is called before the first frame update
    void Start()
    {
        info = transform.parent.parent.GetComponent<InfoGiver>();
        Player = info.Player;
        NewPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        TimePassed += Time.deltaTime;
        float percantagecomplete = TimePassed / Duration;

        if (percantagecomplete < 0.1f)
        {


            transform.position = Vector3.Lerp(transform.position, NewPosition, Mathf.SmoothStep(0, 1, percantagecomplete));
        }
        if (percantagecomplete > 0.1f)
        {

            transform.GetComponent<ConstantForce2D>().force.Set(-2f, 0f);
        }

    }
}
