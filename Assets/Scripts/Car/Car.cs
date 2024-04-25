using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    public Path path;


    public void Set()
    {
        transform.forward = path.entrance.forward;
    }

    public void Reset()
    {
        transform.position = path.entrance.position;
        transform.forward = path.entrance.forward;
    }

  
}
