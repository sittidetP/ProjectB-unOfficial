using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade Instance { get; private set; }
    [SerializeField] protected Image fadeImg;
    [SerializeField] protected float fadeTime;

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
        isFadeIn = false;
        isFadeOut = false;
    }

    void Update()
    {
        if (isFadeIn)
        {
            alphaImage = alphaDelta * (Time.time - startFadeTime) + 1;
            //Debug.Log(alphaSprite);
            fadeImg.color = new Color(1, 1, 1, alphaImage);
        }


    }

    public void FadeIn()
    {
        startFadeTime = Time.time;
        alphaImage = 1f;
        alphaDelta = (0 - alphaImage) / ((startFadeTime + fadeTime) - startFadeTime);
        isFadeIn = true;
    }

    public void FadeOut(){
        startFadeTime = Time.time;
        alphaImage = 0f;
        
    }
}
