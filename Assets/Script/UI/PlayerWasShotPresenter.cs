using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWasShotPresenter : MonoBehaviour
{
    [SerializeField] private PlayerWasShotView playerWasShotView;

    public void UpdateView(int wasShot)
    {
        playerWasShotView.UpdatePlayerWasShotText(wasShot);
    }
}
