using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputController : MonoBehaviour
{
    private Subject<bool> onFireSubject = new Subject<bool>();
    private Subject<Vector2> onMoveSubject = new Subject<Vector2>();
    private Subject<bool> onIsSlowMoveSubject = new Subject<bool>();
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            //Debug.Log("OnFire");
            bool fire = context.ReadValueAsButton();
            onFireSubject.OnNext(fire);
        }
    }

    public void OnMove(Vector2 move)
    {
        onMoveSubject.OnNext(move);
    }

    public void OnIsSlowMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            bool isSlowMove = context.ReadValueAsButton();
            onIsSlowMoveSubject.OnNext(isSlowMove);
        }
    }

    public IObservable<bool> GetFireIObservable()
    {
        return onFireSubject;
    }
    public IObservable<Vector2> GetMoveIObservable()
    {
        return onMoveSubject;
    }
    public IObservable<bool> GetIsSlowMoveIObservable()
    {
        return onIsSlowMoveSubject;
    }

    private void OnDestroy()
    {
        onFireSubject.OnCompleted();
        onMoveSubject.OnCompleted();
        onIsSlowMoveSubject.OnCompleted();
    }
}
