using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseImage : UISceneChanger
{
    public void ResumeButton()
    {
        if (PauseManager.isPause)
        {
            PauseManager.resume();
        }
    }

    public void QuitButton(){
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToStartScene());
    }

    IEnumerator ChangeToStartScene(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        PauseManager.resume();
        ToStartScene();
    }
}
