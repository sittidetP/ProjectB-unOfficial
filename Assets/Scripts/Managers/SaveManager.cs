using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //[SerializeField] Player player;
    public static void SaveGame(Player player){
        SaveSystem.Init();
        int hpPotionAmount = player.Inventory.potions.ContainsKey((int)PotionType.HPPotion) ? player.Inventory.potions[(int)PotionType.HPPotion].Amount : 0;
        int mpPotionAmount = player.Inventory.potions.ContainsKey((int)PotionType.MPPotion) ? player.Inventory.potions[(int)PotionType.MPPotion].Amount : 0;

        int[] potionAmountSave = {hpPotionAmount, mpPotionAmount};

        string projectile1Name = player.Inventory.projectiles[0] != null ? player.Inventory.projectiles[0].name : null;
        string projectile2Name = player.Inventory.projectiles[1] != null ? player.Inventory.projectiles[1].name : null;

        //Debug.Log(projectile1Name +  ", " + projectile2Name);
        string[] projectilesNameSave = {projectile1Name, projectile2Name};
        SaveObject saveObject = new SaveObject{
            position = player.transform.position,
            unlockJumps = player.UnlockJumps,
            unlockDash = player.InputHandler.IsUnlockDash,
            potionsAmount = potionAmountSave,
            projectilesName = projectilesNameSave,
            isSpawnOnces = BoundariesData.isSpawnOnce,
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
