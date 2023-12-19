using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    


    private void Start()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {

            RotateTowardsTarget();
        }
        target = GameObject.Find("Player").transform;
    }


    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}