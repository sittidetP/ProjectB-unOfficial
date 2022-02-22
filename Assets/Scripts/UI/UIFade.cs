using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade Instance { get; private set; }
    [SerializeField] private float fadeTime;
    [SerializeField] private int fadeRate = 30;
    public float FadeTime {get => fadeTime;}
    private Image fadeImg;
    private float startFadeTime;

    private float alphaDelta;
    private float alphaImage;

    public bool IsFading {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fadeImg = GetComponent<Image>();
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        fadeImg = GetComponent<Image>();
        startFadeTime = Time.time;
        SetUpAlphaImage(1);
        StartCoroutine(StartFade(1));        
    }

    public void FadeOut(){
        gameObject.SetActive(true);
        fadeImg = GetComponent<Image>();
        startFadeTime = Time.unscaledTime;
        SetUpAlphaImage(0);
        StartCoroutine(StartFade(0));
    }

    IEnumerator StartFade(int increser){
        IsFading = true;
        float fadeWaitTime = fadeTime/fadeRate;
        for(int i = 0 ; i < fadeRate; ++i){
            float passTime;
            if(increser == 1){
                passTime = Time.time;
            }else{
                passTime = Time.unscaledTime;
            }
            alphaImage = alphaDelta * (passTime - startFadeTime)+  increser;
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
            yield return new WaitForSecondsRealtime(fadeWaitTime);
        }
        IsFading = false;
        gameObject.SetActive(false);
    }

    private void SetUpAlphaImage(float alphaImg){
        alphaImage = alphaImg;
        fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
        alphaDelta = ((1 - alphaImg) - alphaImage) / ((startFadeTime + fadeTime) - startFadeTime);
    }
}
