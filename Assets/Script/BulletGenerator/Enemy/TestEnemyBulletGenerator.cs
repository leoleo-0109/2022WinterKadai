using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBulletGenerator : BulletGeneratorBase
{

    public void BulletGenerate(float bulletSpeed, Transform parent, Vector2 firePos, Vector3 fireAngles)
    {
        //�e�I�u�W�F�N�g�̏�����
        GameObject bulletObj = bulletPool.GetObj(parent);
        bulletObj.transform.position = firePos;
        bulletObj.transform.localEulerAngles = fireAngles;

        //�G�̒e�ω�
        EnemyBulletBase enemyBulletBase = bulletObj.GetComponent<EnemyBulletBase>();
        BulletBase bullet = enemyBulletBase.ChangeBulletComponent("TestEnemyBullet");
        Debug.Log(bullet);

        //�e�̏�����
        bullet.SetBulletPool(bulletPool);
        bullet.SetBulletSpeed(bulletSpeed);

    }
}
