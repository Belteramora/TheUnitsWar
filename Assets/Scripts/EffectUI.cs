using R3;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUI: MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text timeCounter;
    [SerializeField] private List<Sprite> effectSprites;

    public Effect appendedEffect;
    
    public void Setup(Effect appendedEffect)
    {
        this.appendedEffect = appendedEffect;

        switch(appendedEffect.effectType)
        {
            case EffectType.Block:
                spriteRenderer.sprite = effectSprites[0];
                break;
            case EffectType.Regen:
                spriteRenderer.sprite = effectSprites[1];
                break;
            case EffectType.Burning:
                spriteRenderer.sprite = effectSprites[2];
                break;
        }

        appendedEffect.CurrentEffectTime.Subscribe(c => timeCounter.text = c.ToString());
    }
}
