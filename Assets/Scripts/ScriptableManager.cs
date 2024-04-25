using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : MonoBehaviour
{
    public GameData gameData;

    private void OnEnable()
    {
        EventManager.GetGameData += GetGameData;
    }

    private void OnDisable()
    {
        EventManager.GetGameData -= GetGameData;
    }

    private GameData GetGameData()
    {
        return gameData;
    }
}
