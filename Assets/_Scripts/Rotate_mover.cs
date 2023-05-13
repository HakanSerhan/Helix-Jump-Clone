using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_mover : MonoBehaviour
{
    //public float rotateSpeed;
    //private float moveX;
    ////private Touch touch;

    //// Update is called once per frame
    //void Update()
    //{
    //    moveX = Input.GetAxis("Mouse X");

    //    if (Input.GetMouseButton(0))
    //    {

    //        transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
    //    }

    //    //if (Input.touchCount > 0)
    //    //{
    //    //    touch = Input.GetTouch(0);

    //    //    if(touch.phase == TouchPhase.Moved)
    //    //    {
    //    //        transform.Rotate(0, touch.deltaPosition.y * rotateSpeed * Time.deltaTime, 0);
    //    //    }
    //    //}
    //}

    public float rotateSpeed = 5.0f;
    private Vector3 previousPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 currentPosition = touch.position;
                float deltaPositionX = previousPosition.x - currentPosition.x;

                if (deltaPositionX > 0)
                {
                    transform.Rotate(0, -rotateSpeed, 0);
                }
                else if (deltaPositionX < 0)
                {
                    transform.Rotate(0, rotateSpeed, 0);
                }
            }

            previousPosition = touch.position;
        }
    }
}
