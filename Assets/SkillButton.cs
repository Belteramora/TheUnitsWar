using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Action<int> onUseSkillAction;
    private int skillId;

    [SerializeField] private TMP_Text skillNameLabel;
    [SerializeField] private TMP_Text reloadLabel;

    public Button button;

    public void Setup(Action<int> onUseSkillAction, ISkill skill, int skillId)
    {
        this.onUseSkillAction = onUseSkillAction;
        this.skillId = skillId;

        skillNameLabel.text = skill.SkillName;

        skill.SumChargeTimeLast.Subscribe(timeLast =>
        {
            if (timeLast != 0)
                reloadLabel.text = "Перезарядка: " + timeLast + " ходов осталось";
            else
                reloadLabel.text = string.Empty;
        });
    }

    public void OnClick()
    {
        onUseSkillAction.Invoke(skillId);
    }
}
