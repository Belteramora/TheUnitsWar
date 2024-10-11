
using R3;
using ObservableCollections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UnitUI: MonoBehaviour
{
    private List<EffectUI> effectUIs = new List<EffectUI>();

    [SerializeField] private SpriteRenderer hpBar;
    [SerializeField] private TMP_Text currentHP;
    [SerializeField] private TMP_Text maxHP;

    

    [SerializeField] private Transform effectUISpawnPoint;
    [SerializeField] private GameObject effectPrefab;


    public void SetupOnEntity(Entity entity)
    {
        entity.appendedUnit.HP.Subscribe(c => hpBar.size = new Vector2(c / entity.appendedUnit.MaxHP.Value, hpBar.size.y)).AddTo(this);

        entity.appendedUnit.HP.Subscribe(c => currentHP.text = c.ToString()).AddTo(this);

        entity.appendedUnit.MaxHP.Subscribe(c => maxHP.text = c.ToString()).AddTo(this);

        entity.appendedUnit.currentEffects.ObserveAdd().Subscribe(c => SetNewEffect(c.Value)).AddTo(this);

        entity.appendedUnit.currentEffects.ObserveRemove().Subscribe(c => RemoveEffect(c.Value)).AddTo(this);
    }

    public void SetNewEffect(Effect newEffect)
    {


        var effectUIGO = Instantiate(effectPrefab, effectUISpawnPoint);

        var effectUI = effectUIGO.GetComponent<EffectUI>();

        effectUI.Setup(newEffect);

        effectUIs.Add(effectUI);
    }

    public void RemoveEffect(Effect existEffect)
    {
        var effectUI = effectUIs.First(c => c.appendedEffect == existEffect);

        effectUIs.Remove(effectUI);

        Destroy(effectUI.gameObject, 0.01f);
    }
}
