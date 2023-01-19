using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWasShotModel : MonoBehaviour
{
    [SerializeField] private PlayerWasShotPresenter playerWasShotPresenter;
    private int wasShot = 0;

    public void SetWasShot(int wasShot)
    {
        this.wasShot = wasShot;
        playerWasShotPresenter.UpdateView(this.wasShot);
    }

    public int GetWasShot()
    {
        return wasShot;
    }
}
