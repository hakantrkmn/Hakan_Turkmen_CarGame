using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : Car
{
    private float _timer;
    
    float _sampleTime;

    private void Start()
    {
        _sampleTime = EventManager.GetGameData().sampleTime;
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameStates.OnMove)
        {
            _timer += Time.deltaTime;
            if (_timer > _sampleTime)
            {
                EventManager.SampleMovement(transform);
                _timer = 0;
            }
        }
        
    }
}
