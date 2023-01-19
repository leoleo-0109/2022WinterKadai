using System;
using UnityEngine;

public class PlayerBulletGenerator : BulletGeneratorBase
{
    [SerializeField] protected int generateObjNum;

    private void Awake()
    {
        bulletPool.InitPool(generateObjNum);
    }

    public void BulletGenerate(float bulletSpeed, Transform parent, Vector2 firePos, Vector3 fireAngles)
    {
        GameObject bulletobj = bulletPool.GetObj(parent);
        bulletobj.transform.position = firePos;
        bulletobj.transform.localEulerAngles = fireAngles;

        PlayerBullet playerBullet = bulletobj.GetComponent<PlayerBullet>();
        playerBullet.SetBulletPool(bulletPool);
        playerBullet.SetBulletSpeed(bulletSpeed);
    }
}
