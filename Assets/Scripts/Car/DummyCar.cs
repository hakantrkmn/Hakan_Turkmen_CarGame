using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class DummyCar : Car
{
    private Transform _target;

    private Tween carPath;
    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartMoving += StartMoving;
        EventManager.CarPassedThePath += Reset;
    }

    public override void Set()
    {
        base.Set();
        carPath = transform.DOPath(EventManager.GetLastRoad().ToArray(), 5, PathType.CatmullRom).SetSpeedBased(true).SetLookAt(0.01f).SetId("movement").SetAutoKill(false);
        
    }

   

    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.StartMoving -= StartMoving;
        EventManager.CarPassedThePath -= Reset;
    }

    private void StartMoving()
    {
        //Reset();
        CreatePath();
    }

    public override void Reset()
    {
        carPath.Pause();
        base.Reset();
        
    }

   
    // path oluştur dotween ile takip ettir.
    public void CreatePath()
    {
        Debug.Log(carPath);
        carPath.GotoWaypoint(0);
        carPath.Play();
    }

   
}
