public class RegenSkill : DurationSkill
{

    public RegenSkill(int chargeTime, UnitStatus applyingUnit, float effectPower, int effectDuratrion, string skillName) : base(chargeTime, applyingUnit, effectPower, effectDuratrion, skillName, EffectType.Regen)
    {
    }

    public override void UseSkill()
    {
        base.UseSkill();
    }
}
