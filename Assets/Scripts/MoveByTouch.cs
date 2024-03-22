using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{
    float t;
    float touchStartTime;
    Vector3 startPosition;
    Vector3 target;
    public float timeToReachTarget = 0.6f;
    public float minimumTouchTime = 0.1f; // Minimum time (in seconds) for touch to start moving
    public SpriteRenderer spriteRenderer;
    public Sprite Moving;
    public Sprite NotMoving;
    public bool IsMoving;

    [SerializeField] private Slider _slider;

    private void Start()
    {
        startPosition = target = transform.position;
    }

    void Update()
    {
        if (IsMoving)
        {
            spriteRenderer.sprite = Moving;
        }
        else
        {
            spriteRenderer.sprite = NotMoving;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (Time.time - touchStartTime >= minimumTouchTime)
                {
                    IsMoving = true;
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    target = touchPosition;
                    startPosition = transform.position;

                    t += Time.deltaTime / timeToReachTarget;
                    transform.position = Vector3.Lerp(startPosition, target, t);
                    t = 0;
                }
            }
        }
        else
            {
                IsMoving = false;
            }
    }
}
