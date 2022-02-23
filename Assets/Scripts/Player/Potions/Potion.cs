using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] Sprite potionSprite;

    private int amount = 0;
    protected Player player;
    public Sprite PotionSprite {get => potionSprite;}
    public  virtual void UsePotion(){
        amount--;
    }

    public virtual void SetPlayer(Player player){
        this.player=  player;
    }

    public virtual void AddPotionAmount(){
        amount++;
    }
}

public enum PotionType{
    HPPotion,
    MPPotion
}
