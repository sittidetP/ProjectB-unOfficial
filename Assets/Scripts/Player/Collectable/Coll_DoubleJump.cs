using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_DoubleJump : Collectable
{
    protected override void ActionItem(){
        player.ExtraPlayer.AlertTextManager.ShowText("Unlock Double Jump!");
        player.unlockMultipleJump(2);
    }
}
