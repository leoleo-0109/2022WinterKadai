using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    public override void Execute()
    {
        Move();
        ScreenOut();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        TriggerEnter(col);
    }
    protected override void Move()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }

    protected override void TriggerEnter(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("<color=orange>EnemyÇ…ìñÇΩÇ¡ÇΩÇÊÅI</color>");
            bulletPool.DisableObj(gameObject);
        }
    }

}
