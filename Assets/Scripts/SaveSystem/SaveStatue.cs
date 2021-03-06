using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveStatue : MonoBehaviour
{
    [SerializeField] UnityEvent onSaveGame;
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        onEnter?.Invoke();
        player = other.GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(player != null){
            if(player.InputHandler.NormInputY == 1){
                player.Core.Stats.SetHPFull();
                player.ExtraPlayer.PlayerMana.SetMPFull();
                player.InputHandler.SetNormInputYZero();
                onSaveGame?.Invoke();
            }
        }else{
            //print("player null");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            onExit?.Invoke();
            player = null;
        }
    }
}
