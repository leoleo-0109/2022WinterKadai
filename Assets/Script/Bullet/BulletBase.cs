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


    //Update����Ă΂ꂽ�Ƃ���
    public abstract void Execute();
    //�ړ�
    protected abstract void Move();
    //�����������̏���
    protected abstract void TriggerEnter(Collider2D col);
    //��ʊO�ɏo�����̏���
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
