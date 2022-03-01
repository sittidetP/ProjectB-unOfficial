using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] Sprite potionSprite;
    [SerializeField] int maxAmount = 9;
    protected int amount = 0;
    protected Player player;
    public Sprite PotionSprite {get => potionSprite;}
    public int Amount {get => amount;}
    public int MaxAmount {get => maxAmount;}

    public void UsePotion(){
        //print(amount);
        if(amount > 0){
            ActionPotion();
            
        }
    }

    public virtual void SetPlayer(Player player){
        this.player=  player;
    }

    public virtual void AddPotionAmount(){
        if(amount < maxAmount){
            amount++;
        }
    }

    public void SetZeroAmount(){
        amount = 0;
    }

    public void SetAmount(int amount){
        this.amount = amount;
    }

    protected virtual void ActionPotion(){

    }
}

public enum PotionType{
    HPPotion,
    MPPotion
}
