using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] PlayerContinueData playerContinueData;

    private void Awake() {
        if(playerContinueData.isContinue){
            print("continue");
            SaveObject saveObject = SaveManager.LoadGame();
            GameObject playerPack = GameObject.Find("PlayerPack");
            playerPack.transform.position = saveObject.position;
            Player player = playerPack.GetComponentInChildren<Player>();
            player.unlockMultipleJump(saveObject.unlockJumps);
            if(saveObject.unlockDash){
                player.InputHandler.UnlockDash();
            }
            player.Inventory.potions = saveObject.potions;
            player.Inventory.projectiles = saveObject.projectiles;
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
