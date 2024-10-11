
using R3;
using UnityEngine;

public abstract class DurationSkill : Skill
{
    protected Effect ApplyingEffect { get; set; }

    public override ReactiveProperty<bool> AbleToUse { get; set; }

    public DurationSkill(int chargeTime, UnitStatus applyingUnit, float effectPower, int effectDuratrion, string skillName, EffectType effectType) : base(chargeTime, applyingUnit, skillName)
    {
        this.ApplyingEffect = new Effect(effectPower, effectDuratrion, effectType);

        SumChargeTime.Value = chargeTime + effectDuratrion;
    }

    public override void UseSkill()
    {
        ApplyingEffect.CurrentEffectTime.Value = ApplyingEffect.EffectTime.Value;
        SumChargeTimeLast.Value = SumChargeTime.Value;

        ApplyingUnit.currentEffects.Add(ApplyingEffect);
        
        //InUse = true;
    }
}

