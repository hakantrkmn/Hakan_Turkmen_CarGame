using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>() || other.GetComponentInParent<DummyCar>())
        {
            EventManager.CarHitObstacle();
            GameManager.instance.gameState = GameStates.Wait;
        }

        // target colliderına çarptı ve çarptığı target kendi targeti mı
        if (other.GetComponentInParent<Path>() && other.GetComponentInParent<Path>().car == GetComponent<Car>())
        {
            GameManager.instance.gameState = GameStates.Wait;
            EventManager.CarPassedThePath();
        }
        
        
        
    }
}