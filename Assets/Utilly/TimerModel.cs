using UniRx;
using System;
using UnityEngine;
public class TimerModel
{
    //タイマーのリアクティブプロパティ
    private ReactiveProperty<float> timer = new ReactiveProperty<float>(0);
    //制限時間が来た時の通知用
    private Subject<Unit> onLimitSubject = new Subject<Unit>();
    //制限時間
    private float limit = 0;
    //タイマーが止まるかどうか
    private bool isTimerStop = false;
    //タイマーを自動で止めるかどうか
    private bool isAutoTimerStop = false;

    public TimerModel(float limit, bool isAutoTimerStop)
    {
        this.limit = limit;
        this.isAutoTimerStop = isAutoTimerStop;

    }

    public void TimerModelUpdate()
    {
        if (!isTimerStop)
        {
            //タイマーの更新
            timer.Value += Time.deltaTime;
            if(timer.Value > limit)
            {
                if (isAutoTimerStop)
                {
                    //タイマーの値を固定して停止
                    timer.Value = limit;
                    isTimerStop = true;
                }
                else
                {
                    //タイマーを0に戻す
                    timer.Value = 0;
                }
                //制限時間が来たことを通知
                onLimitSubject.OnNext(Unit.Default);
            }
        }
    }

    public IObservable<Unit> GetLimitObservable()
    {
        return onLimitSubject;
    }

    public IReadOnlyReactiveProperty<float> GetTimerIReadOnlyReactiveProperty()
    {
        return timer;
    }

    public void SetIsTimerStop(bool isTimerStop)
    {
        this.isTimerStop = isTimerStop;
    }

    public void SetTimerValue(float value)
    {
        timer.Value = value;

    }
    public void Dispose()
    {
        onLimitSubject.OnCompleted();
        timer.Dispose();
    }
}
