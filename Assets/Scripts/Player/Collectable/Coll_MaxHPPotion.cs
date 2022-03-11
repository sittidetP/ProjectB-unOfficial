using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_MaxHPPotion : Collectable
{
    [SerializeField] float increaseMaxHPAmount = 25;
    protected override void ActionItem(){
        player.ExtraPlayer.AlertTextManager.ShowText("Max HP Increase!");
        player.Core.Stats.IncreaseMaxHealth(increaseMaxHPAmount);
        player.Core.Stats.SetHPFull();
    }
}
