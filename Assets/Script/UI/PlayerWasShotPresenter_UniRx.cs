using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerWasShotPresenter_UniRx : MonoBehaviour
{
    [SerializeField] private PlayerWasShotModel_UniRx playerWasShotModel;
    [SerializeField] private PlayerWasShotView playerWasShotView;

    private void Start()
    {
        playerWasShotModel
            .GetWasShot()
            .Subscribe(wasShot =>
            {
                playerWasShotView.UpdatePlayerWasShotText(wasShot);
            })
            .AddTo(this);
    }
}
