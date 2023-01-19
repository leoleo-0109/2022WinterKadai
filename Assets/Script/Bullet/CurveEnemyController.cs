using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CurveEnemyController : EnemyControllerBase
{
    private TimerModel timerModel = new TimerModel(10000, false);
    private CurveEnemyBulletGenerator curveEnemyBulletGenerator;
    [SerializeField] private float curveBulletSpeed = 1;
    [SerializeField] private int bulletInterval = 10;
    [SerializeField] private float curveSpeed = 0;

    private int frameCount = 0;

    protected override void Awake()
    {
        base.Awake();
        curveEnemyBulletGenerator = GetComponentInChildren<CurveEnemyBulletGenerator>();
        //Debug.Log(testEnemyBulletGenerator);
    }
    private void Start()
    {
        timerModel
            .GetTimerIReadOnlyReactiveProperty()
            .Subscribe(time =>
            {
                Move(time);
            })
            .AddTo(this);
    }

    public override void Execute()
    {
        frameCount++;
        BulletShot(1);
        timerModel.TimerModelUpdate();
    }

    protected override void Move(float time)
    {
        cinemachineDollyCart.m_Position += moveSpeed.Evaluate(time) * Time.deltaTime;
    }

    private void BulletShot(float time)
    {
        if (frameCount >= bulletInterval)
        {
            curveEnemyBulletGenerator.BulletGenerate(
                curveBulletSpeed,
                enemyBulletUsingTransform,
                transform.position,
                new Vector3(0, 0, frameCount),curveSpeed);
            //åÇÇ¬éûä‘çXêV
            frameCount = 0;
        }
    }
}