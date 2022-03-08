using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider sliderBGM;
    [SerializeField] Slider sliderSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGM(float vol){
        if(mixer != null){

        }
    }

    public void SetSE(float vol){
        if(mixer != null){
            
        }
    }
}
