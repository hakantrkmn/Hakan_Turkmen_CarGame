using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public class CarController : MonoBehaviour
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
