using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Path path;

    private float _timer;

    public float sampleTime;
    public void Set()
    {
        transform.forward = path.entrance.forward;
    }

    public void Reset()
    {
        transform.position = path.entrance.position;
        transform.forward = path.entrance.forward;
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameStates.OnMove)
        {
            _timer += Time.deltaTime;
            if (_timer > sampleTime)
            {
                path.AddMovement();
                _timer = 0;
            }
        }
        
    }
}
