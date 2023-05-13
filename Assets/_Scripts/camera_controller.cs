using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smooth;
    void Start()
    {
        offset = transform.position-ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPos = Vector3.Lerp(transform.position, offset + ball.position, smooth);
        transform.position = NewPos;
    }
}
