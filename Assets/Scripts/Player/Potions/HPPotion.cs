using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : Potion
{
    [SerializeField] float healHPAmount = 15f;

    public override void UsePotion()
    {
        base.UsePotion();

        player.Core.Stats.IncreaseHealth(healHPAmount);
    }
}
