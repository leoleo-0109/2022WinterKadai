using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private float screenDestroyOffset = 0;
    protected float bulletSpeed = 0;
    protected ObjectPool bulletPool;
    protected Camera camera;

    protected void Awake()
    {
        camera=Camera.main;
    }


    //Updateから呼ばれたところ
    public abstract void Execute();
    //移動
    protected abstract void Move();
    //当たった時の処理
    protected abstract void TriggerEnter(Collider2D col);
    //画面外に出た時の処理
    protected virtual void ScreenOut()
    {
        Vector3 spos=camera.WorldToScreenPoint(transform.position);
        if (spos.x < 0 - screenDestroyOffset)
        {
            bulletPool.DisableObj(gameObject);
        } else if(spos.x > Screen.width + screenDestroyOffset)
        {
            bulletPool.DisableObj(gameObject);
        }else if (spos.y < 0 - screenDestroyOffset)
        {
            bulletPool.DisableObj(gameObject);
        }
        else if (spos.y > Screen.height + screenDestroyOffset)
        {
            bulletPool.DisableObj(gameObject);
        }
    }
    public void SetBulletPool(ObjectPool pool)
    {
        bulletPool = pool;
    }

    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }
}
