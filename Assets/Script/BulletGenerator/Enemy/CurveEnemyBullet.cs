using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveEnemyBullet : EnemyBulletBase
{
    private float curveSpeed = 0;
    public override void Execute()
    {
        Rotate();
        Move();
        ScreenOut();
    }
    protected override void Move()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }

    private void Rotate()
    {
        transform.localEulerAngles += new Vector3(0, 0, curveSpeed);
    }
    public void SetCurveSpeed(float curveSpeed)
    {
        this.curveSpeed = curveSpeed;
    }
}
