using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIIconManager : MonoBehaviour
{
    public static UIIconManager Instance;
    private Image icon;

    private void Awake() {
        Instance = this;
        icon = GetComponentInChildren<Image>();
    }

    public void SetIcon(Sprite setIcon){
        if(setIcon == null){
            icon.color = new Color(1,1,1,0);
        }else{
            icon.sprite = setIcon;
            icon.color = new Color(255,255,255,1);
        }
    }
}
