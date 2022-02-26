using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveStatue : MonoBehaviour
{
    [SerializeField] UnityEvent onSaveGame;
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
        player = other.GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(player != null){
            if(player.InputHandler.NormInputY == 1){
                player.InputHandler.SetNormInputYZero();
                onSaveGame?.Invoke();
            }
        }else{
            print("player null");
        }
    }
}
