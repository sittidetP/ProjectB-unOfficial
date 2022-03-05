using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_MaxHPPotion : Collectable
{
    [SerializeField] float increaseMaxHPAmount = 25;
    protected override void ActionItem(){
        player.Core.Stats.IncreaseMaxHealth(increaseMaxHPAmount);
        player.Core.Stats.SetHPFull();
    }
}
