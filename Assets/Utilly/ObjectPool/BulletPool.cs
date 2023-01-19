using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
    [SerializeField] private BulletManager bulletManager;

    protected override void GenerateObj(int num)
    {
        base.GenerateObj(num);
        foreach(GameObject poolObj in poolObjs)
        {
            bulletManager.AddBullet(poolObj.GetComponentInChildren<BulletBase>());
        }
    }
}
