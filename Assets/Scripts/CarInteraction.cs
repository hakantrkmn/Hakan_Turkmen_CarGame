using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private CarController _carController;

    private void Start()
    {
        _carController = GetComponentInParent<CarController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>())
        {
            _carController.Reset();
            GameManager.instance.gameState = GameStates.Wait;
        }
    }
}
