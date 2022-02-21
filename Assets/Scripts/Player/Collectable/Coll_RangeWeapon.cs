using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_RangeWeapon : Collectable
{
    [SerializeField] protected GameObject item;
    protected override void ActionItem()
    {
        base.ActionItem();

        RangeWeapon rangeWeapon = item.GetComponent<RangeWeapon>();
        player.Inventory.AddRangeWeapon(rangeWeapon);
    }
}
