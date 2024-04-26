using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public static class EventManager
{
    public static Func<Direction> GetDirection;
    public static Func<Path> GetCurrentPath;
    public static Func<List<Vector3>> GetLastRoad;
    public static Func<GameData> GetGameData;

    public static Action CarPassedThePath;

    public static Action MoveToNextPath;

    public static Action StartMoving;
    public static Action CarHitObstacle;
    public static Action LevelCleared;

    public static Action<Transform> SampleMovement;


}
