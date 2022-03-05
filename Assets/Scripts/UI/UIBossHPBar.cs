using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHPBar : MonoBehaviour
{
    [SerializeField] Enemy boss;
    [SerializeField] Image maskHPBar;
    private float originalMaskHpBarSize;

    private void Start() {
        originalMaskHpBarSize = maskHPBar.rectTransform.rect.width;
    }

    private void Update() {
        if(boss != null){
            SetHPBarValue(boss.Core.Stats.getHPRatio());
        }
    }

    private void SetHPBarValue(float value){
        maskHPBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalMaskHpBarSize * value);
    }
}
