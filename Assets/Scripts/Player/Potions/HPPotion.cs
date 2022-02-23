using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : Potion
{
    [SerializeField] float healHPAmount = 15f;
    [SerializeField] PotionType potionType;

    protected override void ActionPotion()
    {
        base.ActionPotion();

        player.Core.Stats.IncreaseHealth(healHPAmount);
    }
}
