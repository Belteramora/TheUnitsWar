using R3;
using System.Linq;

public class ClearingSkill : Skill
{

    public ClearingSkill(int chargeTime, UnitStatus applyingUnit, string skillName) : base(chargeTime, applyingUnit, skillName)
    {
    }


    public override void UseSkill()
    {
        for (int i = 0; i < ApplyingUnit.currentEffects.Count; i++) 
        {
            if (ApplyingUnit.currentEffects[i].effectType == EffectType.Burning)
                ApplyingUnit.currentEffects.Remove(ApplyingUnit.currentEffects[i]);
        }

        SumChargeTimeLast.Value = SumChargeTime.Value;
    }
}
