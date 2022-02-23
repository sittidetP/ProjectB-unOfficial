using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIHPPotionIcon : MonoBehaviour
{
    public static UIHPPotionIcon Instance;
    [SerializeField] TMP_Text potionAmountText;

    private void Awake() {
        Instance = this;
    }

    public void UpdateAmount(int amount){
        potionAmountText.text = amount.ToString();
    }
}
