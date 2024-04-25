using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private Car _carController;

    private void Start()
    {
        _carController = GetComponentInParent<Car>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>())
        {
            _carController.Reset();
            GameManager.instance.gameState = GameStates.Wait;
        }
        if (other.GetComponentInParent<Path>())
        {
            GameManager.instance.gameState = GameStates.Wait;
            EventManager.CarPassedThePath();
        }
    }
}
