using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance {get; private set;}
    public static bool isPause {get; private set;}

    private void Awake() {
        Instance = this;
    }
    
    public void pause(){
        Time.timeScale = 0;
        isPause = true;
    }

    public void resume(){
        Time.timeScale = 1;
        isPause = false;
    }
}
