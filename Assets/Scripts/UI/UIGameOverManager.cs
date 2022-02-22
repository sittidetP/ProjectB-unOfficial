using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOverManager : UISceneChanger
{
    private void Start() {
        UIFade.Instance.FadeIn();
    }
    public void QuitButton(){
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToStartScene());
    }

    IEnumerator ChangeToStartScene(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        ToStartScene();
    }
}
