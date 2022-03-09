using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StartGameManager : MonoBehaviour
{
    [SerializeField] PlayerContinueData playerContinueData;
    [SerializeField] RangeWeapon icebolt_RangeWeapon;
    [SerializeField] RangeWeapon iceaxe_RangeWeapon;
    [SerializeField] HPPotion hPPotion_base;
    [SerializeField] MPPotion mPPotion_base;
    [SerializeField] UnityEvent onEnableEvent;
    private void OnEnable() {
        onEnableEvent?.Invoke();
    }
    private void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {

        if(playerContinueData.isContinue){
            //print("continue");
            SaveObject saveObject = SaveManager.LoadGame();
            BoundariesData.isSpawnOnce = saveObject.isSpawnOnces;
            GameObject playerPack = GameObject.Find("PlayerPack");
            playerPack.transform.position = saveObject.position;
            Player player = playerPack.GetComponentInChildren<Player>();
            if(saveObject.unlockDash){
                player.InputHandler.UnlockDash();
            }
            player.unlockMultipleJump(saveObject.unlockJumps);
            if(saveObject.potionsAmount[(int)PotionType.HPPotion] > 0){
                int hpPotionAmount = saveObject.potionsAmount[(int)PotionType.HPPotion];
                //print("hpPotion" + hpPotionAmount);
                HPPotion hpPotion = Instantiate(hPPotion_base);
                hpPotion.SetAmount(hpPotionAmount);
                player.Inventory.AddPotionsContinue((int)PotionType.HPPotion, hpPotion);
            }
            if(saveObject.potionsAmount[(int)PotionType.MPPotion] > 0){
                int mpPotionAmount = saveObject.potionsAmount[(int)PotionType.MPPotion];
                //print("mpPotion" + mpPotionAmount);
                MPPotion mpPotion = Instantiate(mPPotion_base);
                mpPotion.SetAmount(mpPotionAmount);
                player.Inventory.AddPotionsContinue((int)PotionType.MPPotion, mpPotion);
            }
            for(int i = 0; i < saveObject.projectilesName.Length; ++i){
                if(saveObject.projectilesName[i].Equals("Icebolt(RangeWeapon)")){
                    player.Inventory.AddRangeWeapon(icebolt_RangeWeapon);
                }else if(saveObject.projectilesName[i].Equals("IceAxe(RangeWeapon)")){
                    player.Inventory.AddRangeWeapon(iceaxe_RangeWeapon);
                }
            }
        }
    }
}
