using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_Dash : Collectable
{
    protected override void ActionItem()
    {
        base.ActionItem();
        player.ExtraPlayer.AlertTextManager.ShowText("Unlock Dash!");
        player.InputHandler.UnlockDash();
    }
}
