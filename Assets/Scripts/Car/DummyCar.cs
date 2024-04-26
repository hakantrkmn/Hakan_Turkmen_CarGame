using DG.Tweening;
using UnityEngine;

public class DummyCar : Car
{
    private Tween _carPath;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.LevelCleared += Move;
        EventManager.StartMoving += Move;
        EventManager.MoveToNextPath += Reset;
    }
    
    public override void Set()
    {
        base.Set();
        var speed = EventManager.GetGameData().carSpeed;
        _carPath = transform.DOPath(EventManager.GetLastRoad().ToArray(), speed, PathType.CatmullRom)
            .SetSpeedBased(true)
            .SetLookAt(0.01f)
            .SetAutoKill(false);
    }


    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.LevelCleared -= Move;
        EventManager.StartMoving -= Move;
        EventManager.MoveToNextPath -= Reset;
    }

    public override void Reset()
    {
        _carPath.Pause();
        base.Reset();
    }

    private void Move()
    {
        _carPath.GotoWaypoint(0);
        _carPath.Play();
    }
}