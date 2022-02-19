using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRangeWeapIcon : MonoBehaviour
//UI RangeWeaponIcon
{
    public static UIRangeWeapIcon Instance;
    private Image icon;

    private void Awake() {
        Instance = this;
        icon = GetComponentInChildren<Image>();
        if(icon != null){
            print("icon not null");
        }
    }

    public void SetRangeWeaponIcon(Sprite rWeapIcon){
        if(rWeapIcon == null){
            icon.color = new Color(1,1,1,0);
        }else{
            icon.sprite = rWeapIcon;
        }
    }
}
