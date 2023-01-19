using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineDollyCart))]
public abstract class EnemyControllerBase : MonoBehaviour
{
    [SerializeField] protected int hp = 1;
    [SerializeField] protected AnimationCurve moveSpeed;
    protected Transform enemyBulletUsingTransform;

    protected CinemachineDollyCart cinemachineDollyCart;

    protected virtual void Awake()
    {
        cinemachineDollyCart = GetComponent<CinemachineDollyCart>();
        enemyBulletUsingTransform = GameObject.FindWithTag("EnemyBulletUsing").transform;
    }

    public abstract void Execute();
    protected abstract void Move(float time);

}
