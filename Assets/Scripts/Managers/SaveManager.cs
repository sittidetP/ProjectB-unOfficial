using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame(Player player){
        SaveSystem.Init();
        int hpPotionAmount = player.Inventory.potions.ContainsKey((int)PotionType.HPPotion) ? player.Inventory.potions[(int)PotionType.HPPotion].Amount : 0;
        int mpPotionAmount = player.Inventory.potions.ContainsKey((int)PotionType.MPPotion) ? player.Inventory.potions[(int)PotionType.MPPotion].Amount : 0;

        int[] potionAmountSave = {hpPotionAmount, mpPotionAmount};
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
