public class AttackSkill : Skill, IShotSkill
{
    public float Damage { get; set; }

    public AttackSkill(int chargeTime, UnitStatus applyingUnit, float damage, string skillName) : base(chargeTime, applyingUnit, skillName)
    {
        Damage = damage;
    }

    public override void UseSkill()
    {
        ApplyingUnit.HPSetter -= 8;
    }
}
