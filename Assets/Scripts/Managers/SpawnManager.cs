using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Path> paths;

    public GameObject pathPrefab;

    int _currentPathIndex;

    public Transform movementParent;
    List<Transform> _movements = new List<Transform>();
    int _movementAmount = 0;
    private List<Vector3> _roadPoints = new List<Vector3>();
    
    private void OnEnable()
    {
        EventManager.CarHitObstacle += () => _movementAmount = 0;
        EventManager.GetLastRoad += () => _roadPoints;
        EventManager.SampleMovement += SampleMovement;
        EventManager.GetCurrentPath += () => paths[_currentPathIndex];
        EventManager.CarPassedThePath += CarPassedThePath;
    }
    private void OnDisable()
    {
        EventManager.CarHitObstacle -= () => _movementAmount = 0;
        EventManager.GetLastRoad -= () => _roadPoints;
        EventManager.SampleMovement -= SampleMovement;
        EventManager.CarPassedThePath -= CarPassedThePath;
        EventManager.GetCurrentPath -= () => paths[_currentPathIndex];
    }

    private void Start()
    {
        for (int i = 0; i < paths.Count; i++)
        {
            if (i==0)
            {
                paths[i].ToggleCanvas(true);
            }
            else
            {
                paths[i].ToggleCanvas(false);
            }
        }
    }


    private void SampleMovement(Transform car)
    {
        if (_movementAmount < _movements.Count)
        {
            var trn = _movements[_movementAmount];
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
            _movements.Add(trn);
            _movementAmount++;
        }
    }

    private void CarPassedThePath()
    {
        _currentPathIndex++;
        CreatePoints();
        paths[_currentPathIndex-1].Passed();
        paths[_currentPathIndex-1].ToggleCanvas(false);
        if (_currentPathIndex >= paths.Count)
        {
            Debug.Log("oyun bitti");
        }
        else
        {
            EventManager.MoveToNextPath();
            _movementAmount = 0;
            paths[_currentPathIndex].ToggleCanvas(true);
        }
        
    }

    void CreatePoints()
    {
        _roadPoints.Clear();
        for (var i = 0; i < _movementAmount; i++)
        {
            _roadPoints.Add(_movements[i].position);
        }
    }
    
    [Button]
    void InstantiatePath()
    {
        var path = PrefabUtility.InstantiatePrefab(pathPrefab, transform);
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
