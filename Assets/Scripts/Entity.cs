
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : IEntity
{
    public string debugName;

    public UnitStatus appendedUnit;

    public List<ISkill> skills;

    public Entity( UnitStatus appendedUnit)
    {
        this.appendedUnit = appendedUnit;
    }

    //TODO: сетап кривой, исправить то, что таргет скилла определяется заранее
    public void SetupSkills(Entity applyingEntity)
    {
        skills = new List<ISkill>()
        {
            new AttackSkill(0, applyingEntity.appendedUnit, 8, "Атака"),
            new BarrierSkill(4, appendedUnit, 5, 2, "Барьер"),
            new RegenSkill(5, appendedUnit, 2, 3, "Регенерация"),
            new FireballSkill(6, applyingEntity.appendedUnit, damage: 1, effectPower: 1, effectDuration: 5, skillName: "Огненный шар"),
            new ClearingSkill(5, appendedUnit, "Очищение")
        };
    }

    public void Reset()
    {
        appendedUnit.ResetUnit();

        foreach (var skill in skills)
        {
            skill.Reset();
        }
    }

    public void TurnPerformed()
    {
        foreach (var skill in skills.Where(c => !c.AbleToUse.Value))
        {
            skill.SumChargeTimeLast.Value--;
        }

        appendedUnit.TurnPerformed();

    }

    public bool UseSkill(int skillId)
    {
        Debug.Log(debugName + " HP: " + appendedUnit.HP.Value + " isDied: " + appendedUnit.IsDied);

        var skill = skills[skillId];

        var able = skill.AbleToUse.Value;
        if (able)
        {
            Debug.Log(debugName + " use skill " + skill.SkillName);

            skill.UseSkill();
        }



        return able;
    }
}
