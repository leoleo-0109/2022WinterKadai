using UnityEngine;

public class TestEnemyBullet : EnemyBulletBase
{

    public override void Execute()
    {
        Move();
        ScreenOut();
    }
    protected override void Move()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }
}
