using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoundaries : MonoBehaviour
{
    [SerializeField] AudioSource themeZoneBGM;
    [SerializeField] AudioSource themeBossZoneBGM;
    private Player player;
    private float enterTime;

    private void Start() {
        PlayThemeZoneBGM(false);
        PlayThemeBossZoneBGM(false);
        //setActiveOjects(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            //setActiveOjects(true);
            PlayThemeZoneBGM(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            //setActiveOjects(false);
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
}
