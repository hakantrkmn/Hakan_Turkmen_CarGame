using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Path> paths;

    public GameObject pathPrefab;

    public int currentPathIndex;

    public Transform movementParent;

    public List<Transform> movements;

    private int _movementAmount = 0;

    private List<Vector3> _roadPoints = new List<Vector3>();
    private void OnEnable()
    {
        EventManager.CarHitObstacle += CarHitObstacle;
        EventManager.GetLastRoad += () => _roadPoints;
        EventManager.SampleMovement += SampleMovement;
        EventManager.GetCurrentPath += GetCurrentPath;
        EventManager.CarPassedThePath += CarPassedThePath;
    }

    private void CarHitObstacle()
    {
        _movementAmount = 0;
    }

  
    private void SampleMovement(Transform car)
    {
        if (_movementAmount < movements.Count)
        {
            var trn = movements[_movementAmount];
            trn.position = car.transform.position;
            trn.forward = car.transform.forward;
            _movementAmount++;
        }
        else
        {
            var trn = new GameObject().transform;
            trn.SetParent(movementParent);
            trn.position = car.transform.position;
            trn.forward = car.transform.forward;
            movements.Add(trn);
            _movementAmount++;
        }
        

    }

    private void CarPassedThePath()
    {
        currentPathIndex++;
        CreatePoints();
        paths[currentPathIndex-1].Passed();
        EventManager.MoveToNextPath();
        _movementAmount = 0;
    }

    void CreatePoints()
    {
        _roadPoints.Clear();
        for (int i = 0; i < _movementAmount; i++)
        {
            _roadPoints.Add(movements[i].position);
        }
    }

    private void OnDisable()
    {
        EventManager.CarHitObstacle -= CarHitObstacle;
        EventManager.GetLastRoad -= () => _roadPoints;
        EventManager.SampleMovement -= SampleMovement;
        EventManager.CarPassedThePath -= CarPassedThePath;
        EventManager.GetCurrentPath -= GetCurrentPath;
    }
    
    

    private Path GetCurrentPath()
    {
        return paths[currentPathIndex];
    }

    [Button]
    void CreatePath()
    {
        var path = Instantiate(pathPrefab, transform);
        paths.Add(path.GetComponent<Path>());
    }
    
    [Button]
    void ClearPaths()
    {
        foreach (var path in paths)
        {
            DestroyImmediate(path.gameObject);
        }
        
        paths.Clear();
    }

}
