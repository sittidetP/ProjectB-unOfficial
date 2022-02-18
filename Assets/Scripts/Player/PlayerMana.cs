using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] float maxMana = 100f;
    [SerializeField] float increaseManaTime = 0.5f;
    [SerializeField] float increaseManaAmount = 1f;
    public float Mana {get ; private set;}
    private float lastInscreaseManaTime;
    // Start is called before the first frame update
    void Start()
    {
        Mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Mana : " + Mana);
        IncreaseMana();
    }

    public bool DecreaseMana(float usedMana){
        if(Mana >= usedMana){
            //print("usedMana : " + usedMana);
            Mana -= usedMana;
            return true;
        }else{
            return false;
        }
    }

    private void IncreaseMana(){
        if(Mana < maxMana){
            if(Time.time >= lastInscreaseManaTime + increaseManaTime){
                Mana += increaseManaAmount;
                lastInscreaseManaTime = Time.time;
            }
        }   
    }
}
