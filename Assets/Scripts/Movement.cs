using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotateSpeed;
    public float forwardSpeed;
    void Update()
    {
        transform.position += transform.forward * (forwardSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            if (EventManager.GetDirection() == Direction.Right)
            {
                transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }
        }
    }
}