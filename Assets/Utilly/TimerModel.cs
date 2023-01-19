using UniRx;
using System;
using UnityEngine;
public class TimerModel
{
    //�^�C�}�[�̃��A�N�e�B�u�v���p�e�B
    private ReactiveProperty<float> timer = new ReactiveProperty<float>(0);
    //�������Ԃ��������̒ʒm�p
    private Subject<Unit> onLimitSubject = new Subject<Unit>();
    //��������
    private float limit = 0;
    //�^�C�}�[���~�܂邩�ǂ���
    private bool isTimerStop = false;
    //�^�C�}�[�������Ŏ~�߂邩�ǂ���
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
            //�^�C�}�[�̍X�V
            timer.Value += Time.deltaTime;
            if(timer.Value > limit)
            {
                if (isAutoTimerStop)
                {
                    //�^�C�}�[�̒l���Œ肵�Ē�~
                    timer.Value = limit;
                    isTimerStop = true;
                }
                else
                {
                    //�^�C�}�[��0�ɖ߂�
                    timer.Value = 0;
                }
                //�������Ԃ��������Ƃ�ʒm
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
