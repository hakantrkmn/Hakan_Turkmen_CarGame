using DG.Tweening;
using UnityEngine;

public class DummyCar : Car
{
    private Transform _target;

    private Tween _carPath;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartMoving += Move;
        EventManager.CarPassedThePath += Reset;
    }

    public override void Set()
    {
        base.Set();
        var speed = EventManager.GetGameData().carSpeed;
        _carPath = transform.DOPath(EventManager.GetLastRoad().ToArray(), speed,PathType.CatmullRom).SetSpeedBased(true)
            .SetLookAt(0.01f).SetId("movement").SetAutoKill(false);
    }


    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.StartMoving -= Move;
        EventManager.CarPassedThePath -= Reset;
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