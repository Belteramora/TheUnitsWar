using R3;
using ObservableCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitStatus
{
    private CompositeDisposable _disposable = new();

    private float _initialHP;

    private float _blockAmount;

    public ReactiveProperty<float> MaxHP { get; set; }
    public ReactiveProperty<float> HP { get; set; }
    public float HPSetter 
    { 
        get
        {
            return HP.Value;
        }
        set
        {
            if (value < HP.Value)
            {
                var diff = HP.Value - value;
                diff -= BlockAmount;
                if(diff > 0)
                    HP.Value -= diff;
            }
            else if(value > HP.Value)
            {
                if(value >= MaxHP.Value)
                    HP.Value = MaxHP.Value;
                else
                    HP.Value = value;
            }
        }
    }

    public ReadOnlyReactiveProperty<bool> IsDied { get; set; }  

    public float BlockAmount
    {
        get => _blockAmount;
        set => _blockAmount = value;
    }

    public ObservableList<Effect> currentEffects { get; set; }

    public UnitStatus(float initialHP, float maxHP)
    {
        HP = new ReactiveProperty<float>(initialHP);
        MaxHP = new ReactiveProperty<float>(initialHP);

        this._initialHP = initialHP;

        currentEffects = new ObservableList<Effect>();

        IsDied = HP.Select(c => c <= 0).ToReadOnlyReactiveProperty();
    }

    public void TurnPerformed()
    {
        if (IsDied.CurrentValue) return;

        foreach(Effect effect in currentEffects)
        {
            switch (effect.effectType)
            {
                case EffectType.Regen:
                    HPSetter += effect.effectPower;
                    break;
                case EffectType.Burning:
                    HPSetter -= effect.effectPower;
                    break;
            }

            effect.CurrentEffectTime.Value--;

        }

        for(int i = 0; i < currentEffects.Count; i++)
        {
            if (currentEffects[i].CurrentEffectTime.Value <= 0)
            {
                Debug.Log("REMOVE EFECT!!!");
                currentEffects.Remove(currentEffects[i]);
            }
        }


    }

    public void ResetUnit()
    {
        HP.Value = _initialHP;
        MaxHP.Value = _initialHP;

        _blockAmount = 0;

        currentEffects.Clear();
    }
}
