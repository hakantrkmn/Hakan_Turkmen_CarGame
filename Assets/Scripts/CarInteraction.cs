using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>())
        {
            EventManager.CarHitObstacle();
            GameManager.instance.gameState = GameStates.Wait;
        }
        if (other.GetComponentInParent<Path>())
        {
            GameManager.instance.gameState = GameStates.Wait;
            EventManager.CarPassedThePath();
        }
    }
}
