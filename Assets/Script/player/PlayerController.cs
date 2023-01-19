using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerShotController playerShotController;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float screenOffset = 0;
    private Vector2 speed = Vector2.zero;
    private bool isSlowMove = false;
    private Camera camera;
    [SerializeField] private PlayerWasShotModel playerWasShotModel;
    [SerializeField] private PlayerWasShotModel_UniRx playerWasShotModel_UniRx;


    private void Awake()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        Move();
        playerShotController.SetPlayerPos(transform.position);
        ScreenOut();
    }


    public void Move()
    {
        if(isSlowMove)
        {
            transform.Translate(speed * speedMultiplier * Time.deltaTime / 2f);
        }
        else
        {
            transform.Translate(speed * speedMultiplier * Time.deltaTime);
        }
    }

    public void OnMoveSpeedUpdate(Vector2 speed)
    {
        this.speed = speed;
    }

    public void OnIsShotUpdate(bool isShot)
    {
        playerShotController.SetIsShot(isShot);
    }
    public void OnIsSlowMoveUpdate(bool isSlowMove)
    {
        this.isSlowMove = isSlowMove;
    }

    public void ScreenOut()
    {
        Vector3 spos = camera.WorldToScreenPoint(transform.position);
        if (spos.x < 0 - screenOffset)
        {
            Vector3 pos = camera.ScreenToWorldPoint(new Vector3(-screenOffset, 0, 0) + new Vector3(0, spos.y, spos.z));
            transform.position = pos;
            spos = new Vector3(-screenOffset, 0, 0) + new Vector3(0, spos.y, spos.z);
        }
        if (spos.x > Screen.width + screenOffset)
        {
            Vector3 pos = camera.ScreenToWorldPoint(new Vector3(screenOffset, 0, 0) + new Vector3(Screen.width, spos.y, spos.z));
            transform.position = pos;
            spos = new Vector3(screenOffset, 0, 0) + new Vector3(Screen.width, spos.y, spos.z);
        }
        if (spos.y < 0 - screenOffset)
        {
            Vector3 pos = camera.ScreenToWorldPoint(new Vector3(0, -screenOffset, 0) + new Vector3(spos.x, 0, spos.z));
            transform.position = pos;
            spos = new Vector3(0, -screenOffset, 0) + new Vector3(spos.x, 0, spos.z);
        }
        if (spos.y > Screen.height + screenOffset)
        {
            Vector3 pos = camera.ScreenToWorldPoint(new Vector3(0, screenOffset, 0) + new Vector3(spos.x, Screen.height, spos.z));
            transform.position = pos;
            spos = new Vector3(0, screenOffset, 0) + new Vector3(spos.x, Screen.height, spos.z);
        }
    }

    public void WasShot()
    {
        int wasShot = playerWasShotModel.GetWasShot();
        wasShot++;
        playerWasShotModel.SetWasShot(wasShot);
    }

    public void WasShot_UniRx()
    {
        int wasShot = playerWasShotModel_UniRx.GetWasShot().Value;
        wasShot++;
        playerWasShotModel_UniRx.SetWasShot(wasShot);
    }
}
