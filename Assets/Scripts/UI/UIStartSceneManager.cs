using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartSceneManager : UISceneChanger
{
    [SerializeField] string gameplayScene;

    private void Awake() {
            
    }

    private void Start() {
        UIFade.Instance.FadeIn();
    }
    public void ToGameplayScene(){
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToGameplayScene());
        
    }

    public void QuitButton(){
        UIFade.Instance.FadeOut();
        StartCoroutine(ChangeToQuitGame());
    }

    IEnumerator ChangeToGameplayScene(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        SceneManager.LoadScene(gameplayScene);
    }

    IEnumerator ChangeToQuitGame(){
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        QuitGame();
    }
}
