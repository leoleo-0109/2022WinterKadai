using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerInputController2PlayerControllerPresenter : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        playerInputController
            .GetMoveIObservable()
            .Subscribe(value =>
            {
                playerController.OnMoveSpeedUpdate(value);
            })
            .AddTo(this);

        playerInputController
            .GetFireIObservable()
            .Subscribe(value =>
            {
                playerController.OnIsShotUpdate(value);
            })
            .AddTo(this);

        playerInputController
            .GetIsSlowMoveIObservable()
            .Subscribe(value =>
            {
                playerController.OnIsSlowMoveUpdate(value);
            })
            .AddTo(this);
    }
}
