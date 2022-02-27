using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] PlayerContinueData playerContinueData;
    [SerializeField] RangeWeapon icebolt_RangeWeapon;
    [SerializeField] RangeWeapon iceaxe_RangeWeapon;

    private void Awake() {
        if(playerContinueData.isContinue){
            print("continue");
            SaveObject saveObject = SaveManager.LoadGame();
            GameObject playerPack = GameObject.Find("PlayerPack");
            playerPack.transform.position = saveObject.position;
            Player player = playerPack.GetComponentInChildren<Player>();
            if(saveObject.unlockDash){
                player.InputHandler.UnlockDash();
            }
            player.unlockMultipleJump(saveObject.unlockJumps);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
