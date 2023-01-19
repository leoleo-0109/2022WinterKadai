using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletBase>bullets =new List<BulletBase>();

    void Update()
    {
        //弾の実行
        foreach(BulletBase bulletBase in bullets)
        {
            if (bulletBase.gameObject.activeSelf)
            {
                bulletBase.Execute();
            }
        }
    }
    //弾リストに追加
    public void AddBullet(BulletBase bullet)
    {
        bullets.Add(bullet);
    }
    //弾リストから削除
    public void RemoveBullet(BulletBase bullet)
    {
        bullets.Remove(bullet);
    }
}
