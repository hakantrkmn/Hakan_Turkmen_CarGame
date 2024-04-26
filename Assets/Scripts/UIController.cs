using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject levelCompletedPanel;

    private void OnEnable()
    {
        EventManager.LevelCleared += LevelCleared;
    }

    private void OnDisable()
    {
        EventManager.LevelCleared -= LevelCleared;
    }

    private void LevelCleared()
    {
        levelCompletedPanel.SetActive(true);
    }
}
