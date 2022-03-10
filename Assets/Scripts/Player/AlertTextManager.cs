using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertTextManager : MonoBehaviour
{
    [SerializeField] TMP_Text alertText;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] float showTime = 1.5f;
    [SerializeField] int fadeRate = 30;
    private float startFadeTime;
    private float startShowTime;

    public void SetTextPosition(Transform transform){
        alertText.gameObject.transform.position = transform.position;
    }
    /*
    private void ShowText(string text){
        alertText.gameObject.SetActive(true);
        alertText.text = text;
        startShowTime = Time.time;
        startFadeTime = Time.time;
        SetUpAlphaText(0);
        isShowing = true;
        StartCoroutine(StartFade(0));  
    }

    private void HideZoneText(){
        //zoneText.gameObject.SetActive(true);
        startFadeTime = Time.time;
        SetUpAlphaText(1);
        StartCoroutine(StartFade(1));  
    }

    private void SetUpAlphaText(float alphaImg){
        alphaText = alphaImg;
        zoneText.color = new Color(zoneText.color.r, zoneText.color.g, zoneText.color.b, alphaImg);
        alphaDelta = ((1 - alphaImg) - alphaText) / ((startFadeTime + fadeTime) - startFadeTime);
    }

    IEnumerator StartFade(int increser){
        float fadeWaitTime = fadeTime/fadeRate;
        for(int i = 0 ; i < fadeRate; ++i){
            float passTime = Time.time;
            alphaText = alphaDelta * (passTime - startFadeTime)+  increser;
            zoneText.color = new Color(zoneText.color.r, zoneText.color.g, zoneText.color.b, alphaText);
            yield return new WaitForSecondsRealtime(fadeWaitTime);
        }
        if(increser == 0){
            
        }else{
            zoneText.gameObject.SetActive(false);
        }
        //zoneText.gameObject.SetActive(false);
    }
    */
}
