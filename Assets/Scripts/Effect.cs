using R3;
using System;
using UnityEngine.UIElements;

public class Effect
{
    public float effectPower;
    public int initEffectTime;

    public EffectType effectType;
    public ReactiveProperty<int> EffectTime { get; set;}
    public ReactiveProperty<int> CurrentEffectTime { get; set; }
    //public float CurrentEffectTime 
    //{
    //    get => _currentEffectTime;
    //    set
    //    {
    //        if(value <= 0 && _currentEffectTime != 0)
    //        {
    //            _currentEffectTime = 0;
    //            onEffectTimeOver?.Invoke();
    //        }
    //        else
    //            _currentEffectTime = value;

    //    }
    //}

    public Effect(float effectPower, int initEffectTime, EffectType effectType)
    {
        this.effectType = effectType;
        this.effectPower = effectPower;
        this.initEffectTime = initEffectTime;
        CurrentEffectTime = new ReactiveProperty<int>(0);
        EffectTime = new ReactiveProperty<int>(initEffectTime);
    }

    public void ResetEffect()
    {
        CurrentEffectTime.Value = 0;
        EffectTime.Value = initEffectTime;

    }
}

public enum EffectType
{
    Regen,
    Block,
    Burning
}
