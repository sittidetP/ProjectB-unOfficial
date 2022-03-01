using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOverManager : UISceneChanger
{
    [SerializeField] string gameplayScene;
    [SerializeField] PlayerContinueData playerContinueData;
    private void Start() {
        UIFade.Instance.FadeIn();
    }
    public void QuitButton(){
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToStartScene());
    }

    public void ContinueToGameplayScene(){
        playerContinueData.isContinue = true;
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToGameplayScene());
    }

    IEnumerator ChangeToGameplayScene(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        SceneManager.LoadScene(gameplayScene);
    }

    IEnumerator ChangeToStartScene(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        ToStartScene();
    }
}
