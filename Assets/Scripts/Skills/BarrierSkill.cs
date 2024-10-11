using R3;
using UnityEngine;

public class BarrierSkill : DurationSkill
{
    public BarrierSkill(int chargeTime, UnitStatus applyingUnit, float effectPower, int effectDuratrion, string skillName) : base(chargeTime, applyingUnit, effectPower, effectDuratrion, skillName, EffectType.Block)
    {
    }

    public override void UseSkill()
    {
        base.UseSkill();
        ApplyingUnit.BlockAmount += ApplyingEffect.effectPower;


        ApplyingEffect.CurrentEffectTime.Where(c => c <= 0).Take(1).Subscribe(c =>
        {
            ApplyingUnit.BlockAmount -= ApplyingEffect.effectPower;
            Debug.Log("decrease block");
        });
    }
}
