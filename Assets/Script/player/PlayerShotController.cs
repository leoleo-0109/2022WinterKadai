using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerShotController : MonoBehaviour
{
    [SerializeField] private PlayerBulletGenerator playerBulletGenerator;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Vector2 firePos;
    [SerializeField] private float fireAngles;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotInterval = 0.1f;
    private TimerModel timerModel;
    private bool isShot = false;
    private Vector2 playerPos = Vector2.zero;


    private void Awake()
    {
        timerModel = new TimerModel(shotInterval, false);
    }
    private void Start()
    {
        timerModel
            .GetLimitObservable()
            .Subscribe(_ =>
            {
                if (isShot)
                {
                    Shot();
                }
            })
            .AddTo(this);
    }
    private void Update()
    {
        timerModel.TimerModelUpdate();
    }
    private void Shot()
    {
        playerBulletGenerator
            .BulletGenerate(bulletSpeed, bulletParent, playerPos + firePos, new Vector3(0, 0, fireAngles));
    }
    public void SetIsShot(bool isShot)
    {
        this.isShot = isShot;

        if (isShot)
        {
            timerModel.SetTimerValue(0);
            Shot();
        }
    }

    public void SetPlayerPos(Vector2 playerPos)
    {
        this.playerPos = playerPos;

    }
    private void OnDestroy()
    {
        timerModel.Dispose();
    }

    public float GetShotInterval()
    {
        return shotInterval;
    }
}
