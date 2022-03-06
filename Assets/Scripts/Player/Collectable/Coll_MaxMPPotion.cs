using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_MaxMPPotion : Collectable
{
    [SerializeField] float increaseMaxMPAmount = 25;
    protected override void ActionItem(){
        player.ExtraPlayer.PlayerMana.IncreaseMaxMana(increaseMaxMPAmount);
        player.ExtraPlayer.PlayerMana.SetMPFull();
    }
}
