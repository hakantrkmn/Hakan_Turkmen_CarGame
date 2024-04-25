using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab;

    private void Start()
    {
        SpawnNextCar();
    }

    void SpawnNextCar()
    {
        var path = EventManager.GetCurrentPath();
        var car = Instantiate(carPrefab, path.entrance.position, quaternion.identity, transform).GetComponent<CarController>();
        car.path = path;
        car.Set();
    }
}
