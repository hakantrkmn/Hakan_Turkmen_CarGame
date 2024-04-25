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

    private void OnEnable()
    {
        EventManager.GetCurrentPath += GetCurrentPath;
    }

    private void OnDisable()
    {
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
