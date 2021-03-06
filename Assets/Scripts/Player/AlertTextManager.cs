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
    private bool isShowing;
    private float alphaText;
    private float alphaDelta;

    public void SetTextPosition(Transform transform){
        alertText.gameObject.transform.position = transform.position;
    }
    
    public void ShowText(string text){
        alertText.gameObject.SetActive(true);
        SetUpAlphaText(0);
        SetUpAlphaText(1);
        isShowing = true;
        alertText.text = text;
        startShowTime = Time.time;
        startFadeTime = Time.time;
        
        
        //StartCoroutine(StartFade(0));  
    }

    private void HideZoneText(){
        //zoneText.gameObject.SetActive(true);
        startFadeTime = Time.time;
        SetUpAlphaText(1);
        StartCoroutine(StartFade(1));  
    }

    private void Update() {
        if(Time.time > startShowTime + showTime && isShowing){
            isShowing = false;
            HideZoneText();
        }
    }

    private void SetUpAlphaText(float alphaImg){
        alphaText = alphaImg;
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alphaImg);
        alphaDelta = ((1 - alphaImg) - alphaText) / ((startFadeTime + fadeTime) - startFadeTime);
    }

    IEnumerator StartFade(int increser){
        float fadeWaitTime = fadeTime/fadeRate;
        for(int i = 0 ; i < fadeRate; ++i){
            float passTime = Time.time;
            alphaText = alphaDelta * (passTime - startFadeTime)+  increser;
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alphaText);
            yield return new WaitForSecondsRealtime(fadeWaitTime);
        }
        if(increser == 0){
            
        }else{
            alertText.gameObject.SetActive(false);
        }
        //zoneText.gameObject.SetActive(false);
    }
    
}
