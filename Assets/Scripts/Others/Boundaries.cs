using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    int index;
    public int Index {get => index;}
    [SerializeField] GameObject[] objects;

    private Player player;

    private void Start() {
        setActiveOjects(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            setActiveOjects(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            setActiveOjects(false);
        }
    }

    private void setActiveOjects(bool value){
        foreach(GameObject obj in objects){
            obj.gameObject.SetActive(value);
        }
    }

    public void SetIndex(int value){
        index = value;
    }
}
