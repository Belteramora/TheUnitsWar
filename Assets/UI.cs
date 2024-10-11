using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class UI : MonoBehaviour
{
    private Action<int> onUseSkill;

    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject buttonPrefab;

    [SerializeField] private Transform buttonContainer;

    public void Setup(Action<int> onUseSkill, Entity playerEntity)
    {
        this.onUseSkill = onUseSkill;

        for(int i = 0; i < playerEntity.skills.Count; i++)
        {
            var buttonGO = Instantiate(buttonPrefab, buttonContainer);

            var skillButton = buttonGO.GetComponent<SkillButton>();

            skillButton.Setup(UseSkill, playerEntity.skills[i], i);

            playerEntity.skills[i].AbleToUse.Subscribe(x => skillButton.button.interactable = x).AddTo(this);
        }

        //for(int i = 0; i < )
    }

    public void UseSkill(int skillId)
    {
        onUseSkill.Invoke(skillId);
    }


    public void BlockUI()
    {
        canvasGroup.interactable = false;
    }

    public void UnblockUI()
    {
        canvasGroup.interactable = true;
    }
}
