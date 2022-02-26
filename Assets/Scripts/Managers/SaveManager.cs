using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame(Player player){
        SaveSystem.Init();
        SaveObject saveObject = new SaveObject{
            position = player.transform.position,
            projectiles = player.Inventory.projectiles,
            unlockJumps = player.PlayerStateData.amountOfJump,
            unlockDash = player.InputHandler.IsUnlockDash,
            potions = player.Inventory.potions,
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
    }

    public static SaveObject LoadGame(){
        string saveString = SaveSystem.Load();
        if(saveString != null){
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            return saveObject;
        }
        return null;
    }
}
