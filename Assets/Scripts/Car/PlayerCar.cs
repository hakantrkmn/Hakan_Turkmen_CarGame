using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : Car
{
    private float _timer;

    public float sampleTime;

    private void Update()
    {
        if (GameManager.instance.gameState == GameStates.OnMove)
        {
            _timer += Time.deltaTime;
            if (_timer > sampleTime)
            {
                EventManager.SampleMovement(transform);
                _timer = 0;
            }
        }
        
    }
}
