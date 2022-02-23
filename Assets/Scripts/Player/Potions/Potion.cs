using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] Sprite potionSprite;
    protected int amount = 0;
    protected Player player;
    public Sprite PotionSprite {get => potionSprite;}
    public int Amount {get => amount;}
    public void UsePotion(){
        if(amount > 0){
            ActionPotion();
            amount--;
        }
    }

    public virtual void SetPlayer(Player player){
        this.player=  player;
    }

    public virtual void AddPotionAmount(){
        amount++;
    }

    protected virtual void ActionPotion(){

    }
}

public enum PotionType{
    HPPotion,
    MPPotion
}
