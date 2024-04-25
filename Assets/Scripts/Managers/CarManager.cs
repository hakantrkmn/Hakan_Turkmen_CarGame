using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab;

    private void OnEnable()
    {
        EventManager.MoveToNextPath += MoveToNextPath;
    }

    private void OnDisable()
    {
        EventManager.MoveToNextPath -= MoveToNextPath;
    }

    private void MoveToNextPath()
    {
        SpawnNextCar();
    }

    private void Start()
    {
        SpawnNextCar();
    }

    void SpawnNextCar()
    {
        var path = EventManager.GetCurrentPath();
        var car = Instantiate(carPrefab, path.entrance.position, quaternion.identity, transform).GetComponent<Car>();
        car.path = path;
        path.car = car;
        car.Set();
    }
}
