using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image maskHpBar;
    [SerializeField] Image maskMpBar;
    [SerializeField] Image pauseImage;
    private float originalMaskHpBarSize;
    private float originalMaskMpBarSize;

    public static UIManager Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalMaskHpBarSize = maskHpBar.rectTransform.rect.width;
        originalMaskMpBarSize = maskMpBar.rectTransform.rect.width;
        
        UIFade.Instance?.FadeIn();
        PauseManager.resume();
    }

    private void Update() {
        if(PauseManager.isPause){
            pauseImage.gameObject.SetActive(true);
        }else{
            pauseImage.gameObject.SetActive(false);
        }
    }

    public void SetHPBarValue(float value){
        maskHpBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalMaskHpBarSize * value);
    }

    public void SetMPBarValue(float value){
        maskMpBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalMaskHpBarSize * value);
    }
}
