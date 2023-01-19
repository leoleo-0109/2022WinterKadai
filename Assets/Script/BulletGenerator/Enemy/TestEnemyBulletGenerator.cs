using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBulletGenerator : BulletGeneratorBase
{

    public void BulletGenerate(float bulletSpeed, Transform parent, Vector2 firePos, Vector3 fireAngles)
    {
        //弾オブジェクトの初期化
        GameObject bulletObj = bulletPool.GetObj(parent);
        bulletObj.transform.position = firePos;
        bulletObj.transform.localEulerAngles = fireAngles;

        //敵の弾変化
        EnemyBulletBase enemyBulletBase = bulletObj.GetComponent<EnemyBulletBase>();
        BulletBase bullet = enemyBulletBase.ChangeBulletComponent("TestEnemyBullet");
        Debug.Log(bullet);

        //弾の初期化
        bullet.SetBulletPool(bulletPool);
        bullet.SetBulletSpeed(bulletSpeed);

    }
}
