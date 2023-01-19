using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletBase>bullets =new List<BulletBase>();

    void Update()
    {
        //�e�̎��s
        foreach(BulletBase bulletBase in bullets)
        {
            if (bulletBase.gameObject.activeSelf)
            {
                bulletBase.Execute();
            }
        }
    }
    //�e���X�g�ɒǉ�
    public void AddBullet(BulletBase bullet)
    {
        bullets.Add(bullet);
    }
    //�e���X�g����폜
    public void RemoveBullet(BulletBase bullet)
    {
        bullets.Remove(bullet);
    }
}
