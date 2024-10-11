using R3;
using UnityEditor;

public interface ISkill
{
    string SkillName { get; set; }

    UnitStatus ApplyingUnit { get; set; }
    ReactiveProperty<bool> AbleToUse { get; }
    ReactiveProperty<int> SumChargeTime { get; set; }
    ReactiveProperty<int> SumChargeTimeLast { get; set; }
    ReactiveProperty<int> ChargeTimeInTurns { get; set; }
    
    void UseSkill();

    void Reset();
}
