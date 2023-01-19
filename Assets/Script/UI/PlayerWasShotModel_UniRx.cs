using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerWasShotModel_UniRx : MonoBehaviour
{
    private ReactiveProperty<int> wasShot= new ReactiveProperty<int>(0);

    public void SetWasShot(int wasShot)
    {
        this.wasShot.Value = wasShot;
    }

    public IReadOnlyReactiveProperty<int> GetWasShot()
    {
        return wasShot;
    }
}
