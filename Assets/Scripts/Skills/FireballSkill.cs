public class FireballSkill : DurationSkill, IShotSkill
{
    public float Damage { get; set; }

    //TODO: чет намудрил с конструкторами, надо переделать


    public FireballSkill(int chargeTime, UnitStatus applyingUnit, float damage, float effectPower, int effectDuration, string skillName) : base(chargeTime, applyingUnit, effectPower, effectDuration, skillName, EffectType.Burning)
    {
        Damage = damage;
    }

    public override void UseSkill()
    {
        ApplyingUnit.HPSetter -= Damage;
        base.UseSkill();
    }
}
