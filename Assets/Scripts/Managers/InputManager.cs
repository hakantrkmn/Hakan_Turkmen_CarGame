using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private readonly float _middleOfScreen = Screen.width / 2;
    private void OnEnable()
    {
        EventManager.GetDirection += GetDirection;
    }

    private Direction GetDirection()
    {
        if (Input.mousePosition.x > _middleOfScreen)
        {
            return Direction.Left;
        }
        else
        {
            return Direction.Right;
        }
    }

   
}
