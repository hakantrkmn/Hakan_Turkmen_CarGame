using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    public Path path;

    protected virtual void OnEnable()
    {
        EventManager.CarHitObstacle += Reset;
    }

    protected virtual void OnDisable()
    {
        EventManager.CarHitObstacle -= Reset;

    }

    public virtual void Set()
    {
        transform.forward = path.entrance.forward;
    }

    public virtual void Reset()
    {
        transform.position = path.entrance.position;
        transform.forward = path.entrance.forward;
    }

  
}
