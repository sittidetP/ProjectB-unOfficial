using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseImage : MonoBehaviour
{
    private string startScene = "StartScene";
    public void ResumeButton()
    {
        if (PauseManager.isPause)
        {
            PauseManager.resume();
        }
    }

    public void QuitButton(){
        SceneManager.LoadScene(startScene);
    }
}
