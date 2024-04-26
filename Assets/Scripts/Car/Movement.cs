using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float _rotateSpeed;
    float _forwardSpeed;

    public Transform rotatePoint;

    private void Start()
    {
        var data = EventManager.GetGameData();
        _rotateSpeed = data.carRotateSpeed;
        _forwardSpeed = data.carSpeed;
    }

    void Update()
    {
        if (GameManager.instance.gameState == GameStates.OnMove)
        {
            transform.position += transform.forward * (_forwardSpeed * Time.deltaTime);
            if (Input.GetMouseButton(0))
            {
                if (EventManager.GetDirection() == Direction.Right)
                {
                    transform.RotateAround(rotatePoint.position,Vector3.up, -_rotateSpeed * Time.deltaTime);
                }
                else
                {
                    transform.RotateAround(rotatePoint.position,Vector3.up, _rotateSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.gameState = GameStates.OnMove;
                if (EventManager.StartMoving != null)
                {
                    EventManager.StartMoving();
                }
            }
        }
    }
}