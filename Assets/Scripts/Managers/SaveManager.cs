using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame(Player player){
        SaveSystem.Init();
        int[] potionAmountSave = {player.Inventory.potions[(int)PotionType.HPPotion].Amount,
         player.Inventory.potions[(int)PotionType.MPPotion].Amount};
        SaveObject saveObject = new SaveObject{
            position = player.transform.position,
            unlockJumps = player.UnlockJumps,
            unlockDash = player.InputHandler.IsUnlockDash,
            potionsAmount = potionAmountSave
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
