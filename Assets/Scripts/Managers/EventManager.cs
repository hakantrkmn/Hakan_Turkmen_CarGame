using System;
using System.Collections;
using System.Collections.Generic;
using CarGame;
using UnityEngine;

public static class EventManager
{
    public static Func<Direction> GetDirection;
    public static Func<Path> GetCurrentPath;

    public static Action CarPassedThePath;

    public static Action MoveToNextPath;

}
