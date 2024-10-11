
using R3;
using UnityEngine.UIElements;

public abstract class Skill : ISkill
{

    protected CompositeDisposable _disposables = new();
    public string SkillName { get; set; }
    public UnitStatus ApplyingUnit { get; set; }

    public virtual ReactiveProperty<bool> AbleToUse { get; set; }

    public ReactiveProperty<int> SumChargeTime { get; set; }
    public ReactiveProperty<int> SumChargeTimeLast { get; set; }
    public ReactiveProperty<int> ChargeTimeInTurns { get; set; }

    public Skill(int chargeTime, UnitStatus applyingUnit, string skillName)
    {

        ApplyingUnit = applyingUnit;

        SumChargeTime = new ReactiveProperty<int>(chargeTime);
        SumChargeTimeLast = new ReactiveProperty<int>(0);
        ChargeTimeInTurns = new ReactiveProperty<int>(chargeTime);

        AbleToUse = SumChargeTimeLast.Select(c => c <= 0).ToBindableReactiveProperty();
        this.SkillName = skillName;
    }

    public abstract void UseSkill();

    public virtual void Reset()
    {
        SumChargeTimeLast.Value = 0;
    }
}

