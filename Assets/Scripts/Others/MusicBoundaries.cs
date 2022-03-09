using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicBoundaries : MonoBehaviour
{
    [SerializeField] string zoneName;
    [SerializeField] AudioSource themeZoneBGM;
    [SerializeField] AudioSource themeBossZoneBGM;
    [SerializeField] TMP_Text zoneText;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] float showTime = 3f;
    [SerializeField] int fadeRate = 30;
    private Player player;
    private float enterTime;
    private float startFadeTime;
    private float startShowTime;
    private float alphaText;
    private float alphaDelta;
    private bool isShowing;

    private void Start() {
        PlayThemeZoneBGM(false);
        PlayThemeBossZoneBGM(false);
        //setActiveOjects(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            //setActiveOjects(true);
            ShowZoneText();
            PlayThemeZoneBGM(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            //setActiveOjects(false);
            SetUpAlphaText(1);
            zoneText.gameObject.SetActive(false);
            PlayThemeZoneBGM(false);
        }
    }

    public void PlayThemeZoneBGM(bool canPlay){
        if(canPlay){
            themeZoneBGM.Play();
        }else{
            themeZoneBGM.Stop();
        }
    }

    public void PlayThemeBossZoneBGM(bool canPlay){
        if(canPlay){
            themeBossZoneBGM.Play();
        }else{
            themeBossZoneBGM.Stop();
        }
    }

    private void Update() {
        if(Time.time > startShowTime + showTime && isShowing){
            isShowing = false;
            HideZoneText();
        }
    }

    private void ShowZoneText(){
        zoneText.gameObject.SetActive(true);
        zoneText.text = zoneName;
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
}
