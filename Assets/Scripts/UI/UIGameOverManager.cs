using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIGameOverManager : UISceneChanger
{
    [SerializeField] string gameplayScene;
    [SerializeField] PlayerContinueData playerContinueData;
    [SerializeField] AudioSource gameOverAudio;
    [SerializeField] UnityEvent<bool> onAwake;
    [SerializeField] UnityEvent onEndMusic;
    private void Start() {
        onAwake?.Invoke(SaveSystem.HasSave());
        UIFade.Instance.FadeIn();
    }

    private void Update() {
        /*
        if(!gameOverAudio.isPlaying){
            onEndMusic?.Invoke();
        }
        */
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
