using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_Potion : Collectable
{
    [SerializeField] Potion potion;
    [SerializeField] PotionType potionType;
    protected override void ActionItem()
    {
        base.ActionItem();
        potion.SetPlayer(player);
        player.Inventory.AddPotions((int) potionType,potion);
    }

    protected override bool canCollect() {
        return !player.Inventory.PotionAmountIsMax((int)potionType);
    }
}
