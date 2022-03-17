using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RedOrb : MonoBehaviour
{
    [SerializeField] Coll_OrbEndGame redOrb;
    [SerializeField] string sceneName;
    [SerializeField] AudioSource allClearBGM;
    [SerializeField] UnityEvent onCollect;
    [SerializeField] UnityEvent onEndGame;
    private bool collectRedOrb;
    private bool isEnd;
    private void Update() {
        if(redOrb == null && !collectRedOrb){
            collectRedOrb = true;
            allClearBGM.Play();
            onCollect?.Invoke();
        }

        if(collectRedOrb && !allClearBGM.isPlaying && !isEnd){
            isEnd = true;
            UIFade.Instance.FadeOut();
            PauseManager.resume();
            StartCoroutine(ChangeScene(sceneName));
        }
    }

    IEnumerator ChangeScene(string sceneName){
        yield return new WaitForSeconds(UIFade.Instance.FadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
