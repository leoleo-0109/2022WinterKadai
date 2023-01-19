using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestEnemyController : EnemyControllerBase
{
    private TimerModel timerModel = new TimerModel(10000, false);
    private TestEnemyBulletGenerator testEnemyBulletGenerator;
    [SerializeField] private float testBulletSpeed = 1;
    [SerializeField] private float testBulletInterval = 1;
    private float testBulletShotTime = 0;

    protected override void Awake()
    {
        base.Awake();
        testEnemyBulletGenerator = GetComponentInChildren<TestEnemyBulletGenerator>();
        //Debug.Log(testEnemyBulletGenerator);
    }

    private void Start()
    {
        timerModel
            .GetTimerIReadOnlyReactiveProperty()
            .Subscribe(time =>
            {
                Move(time);
                TestBulletShot(time);
            })
            .AddTo(this);
    }
    public override void Execute()
    {
        timerModel.TimerModelUpdate();
    }

    protected override void Move(float time)
    {
        cinemachineDollyCart.m_Position += moveSpeed.Evaluate(time) * Time.deltaTime;
    }

    private void TestBulletShot(float time)
    {
        if (time % testBulletInterval < 1)
        {
            testEnemyBulletGenerator.BulletGenerate(
                testBulletSpeed,
                enemyBulletUsingTransform,
                transform.position,
                new Vector3(0, 0, time * 20));
            //Œ‚‚ÂŽžŠÔXV
            testBulletShotTime += testBulletInterval;
        }
    }
}