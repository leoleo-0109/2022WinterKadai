using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.InternalUtil;
using UnityEngine;

public class EnemyBulletBase : BulletBase
{
    private BulletManager bulletManager;

    private void Awake()
    {
        base.Awake();
        bulletManager = GameObject.FindGameObjectWithTag("EnemyBulletManager").GetComponent<BulletManager>();
    }
    public BulletBase ChangeBulletComponent(string componentName)
    {
        switch (componentName)
        {
            case "TestEnemyBullet":
                bulletManager.RemoveBullet(this);
                TestEnemyBullet testbullet = gameObject.AddComponent<TestEnemyBullet>();
                bulletManager.AddBullet(testbullet);
                Destroy(this);
                return testbullet;
            case "CurveEnemyBullet":
                bulletManager.RemoveBullet(this);
                CurveEnemyBullet curvebullet = gameObject.AddComponent<CurveEnemyBullet>();
                bulletManager.AddBullet(curvebullet);
                Destroy(this);
                return curvebullet;
            default:
                throw new Exception("componentNameが不正です！："+ componentName);
        }
    }

    public override void Execute()
    {

    }

    protected override void Move()
    {

    }

    protected override void TriggerEnter(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("<color=yellow>Playerに当たったよ！</color>");
            //col.GetComponent<PlayerController>().WasShot();
            col.GetComponent<PlayerController>().WasShot_UniRx();
            bulletPool.DisableObj(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        TriggerEnter(col);
    }
}
