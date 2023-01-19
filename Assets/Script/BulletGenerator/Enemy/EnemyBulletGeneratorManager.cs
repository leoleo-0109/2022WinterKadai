using UnityEngine;

public class EnemyBulletGeneratorManager : BulletGeneratorBase
{
    [SerializeField] private int generateObjNum;
    void Awake()
    {
        bulletPool.InitPool(generateObjNum);
    }
}
