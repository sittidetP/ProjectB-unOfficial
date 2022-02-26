using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPause {get; private set;}
    public static bool IsNormPlay {get; set;}

    private void Start() {
        IsNormPlay = true;
    }

    public static void pause(){
        Time.timeScale = 0;
        isPause = true;
    }

    public static void resume(){
        Time.timeScale = 1;
        isPause = false;
    }
}
