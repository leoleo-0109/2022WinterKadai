using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveEnemyBulletGenerator : BulletGeneratorBase
{

    public void BulletGenerate(float bulletSpeed, Transform parent, Vector2 firePos, Vector3 fireAngles, float curveSpeed)
    {
        //�e�I�u�W�F�N�g�̏�����
        GameObject bulletObj = bulletPool.GetObj(parent);
        bulletObj.transform.position = firePos;
        bulletObj.transform.localEulerAngles = fireAngles;

        //�G�̒e�ω�
        EnemyBulletBase enemyBulletBase = bulletObj.GetComponent<EnemyBulletBase>();
        BulletBase bullet = enemyBulletBase.ChangeBulletComponent("CurveEnemyBullet");
        //Debug.Log(bullet);
        if(bullet is CurveEnemyBullet)
        {
            CurveEnemyBullet curveEnemyBullet = (CurveEnemyBullet)bullet;
            curveEnemyBullet.SetCurveSpeed(curveSpeed);
        }

        //�e�̏�����
        bullet.SetBulletPool(bulletPool);
        bullet.SetBulletSpeed(bulletSpeed);

    }
}
