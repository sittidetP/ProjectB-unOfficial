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

    public override void ToStartScene()
    {
        StartCoroutine(FadeOut());
        base.ToStartScene();
    }

    IEnumerator FadeOut(){
        UIFade.Instance.FadeOut();
        yield return new WaitForSeconds(UIFade.Instance.FadeTime);
    }
}
