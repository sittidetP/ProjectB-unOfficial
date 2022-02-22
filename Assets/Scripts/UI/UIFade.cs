using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade Instance { get; private set; }
    [SerializeField] private float fadeTime;

    public float FadeTime {get => fadeTime;}
    private Image fadeImg;
    private float startFadeTime;

    private float alphaDelta;
    private float alphaImage;

    private bool isFadeIn;
    private bool isFadeOut;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fadeImg = GetComponent<Image>();
    }

    void Update()
    {
        if (isFadeIn && alphaImage > 0)
        {
            
            alphaImage = alphaDelta * (Time.time - startFadeTime) + 1;
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
        }else if(isFadeIn && alphaImage <= 0){
            alphaImage = 0;
            gameObject.SetActive(false);
        }

        if(isFadeOut && alphaImage < 1){
            alphaImage = alphaDelta * (Time.time - startFadeTime);
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
        }else if(isFadeOut && alphaImage >= 1){
            alphaImage = 1;
            gameObject.SetActive(false);
        }
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        fadeImg = GetComponent<Image>();
        startFadeTime = Time.time;
        alphaImage = 1f;
        fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
        alphaDelta = (0 - alphaImage) / ((startFadeTime + fadeTime) - startFadeTime);
        isFadeIn = true;
    }

    public float FadeOut(){
        gameObject.SetActive(true);
        fadeImg = GetComponent<Image>();
        startFadeTime = Time.time;
        alphaImage = 0f;
        fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, alphaImage);
        alphaDelta = (1 - alphaImage) / ((startFadeTime + fadeTime) - startFadeTime);
        isFadeOut = true;
        return alphaImage;
    }
}
