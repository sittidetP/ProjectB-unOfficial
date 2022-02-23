using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPotion : Potion
{
    [SerializeField] float healMPAmount = 15f;
    [SerializeField] PotionType potionType;

    protected override void ActionPotion()
    {
        base.ActionPotion();
        if (!player.ExtraPlayer.PlayerMana.isMPPotion())
        {
            player.ExtraPlayer.PlayerMana.IncreaseMana(healMPAmount);
            amount--;
        }
    }
}
