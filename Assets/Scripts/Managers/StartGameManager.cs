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
            if(saveObject.player != null){
                print("player save not null");
            }else{
                print("null");
            }
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
