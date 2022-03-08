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
    private float bgmVol = 0;
    private float seVol = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetBGM(float vol){
        if(mixer != null){
            mixer.SetFloat("BGM_VOL", vol);
            bgmVol = vol;
            sliderBGM.value = vol;
        }
    }

    public void SetSE(float vol){
        if(mixer != null){
            mixer.SetFloat("SE_VOL", vol);
            mixer.SetFloat("SE_E_VOL", vol);
            mixer.SetFloat("SE_P_VOL", vol);
            seVol = vol;
            sliderSFX.value = vol;
        }
    }

    public void SaveVolumeSetting(){
        SaveOptionObject saveOptionObject = new SaveOptionObject{
            bgmVol = bgmVol,
            seVol = seVol
        };
        string json = JsonUtility.ToJson(saveOptionObject);
        SaveSystem.SaveOption(json);
    }

    private void LoadVolumeSetting(){
        
    }
}
