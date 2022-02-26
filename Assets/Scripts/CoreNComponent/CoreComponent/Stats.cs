using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    private bool isDeaded;
    private bool isAlreadyDeaded;
    protected override void Awake()
    {
        base.Awake();
        isDeaded = false;
        isAlreadyDeaded = false;
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount){
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDeaded = true;
        }
    }

    public void IncreaseHealth(float amount){
        currentHealth += amount;

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHealth(float amount){
        maxHealth += amount;
    }

    public void SetHealthToMax(){
        currentHealth = maxHealth;
    }

    public bool isHealthFull(){
        return currentHealth == maxHealth;
    }

    public bool getIsDead(){
        return isDeaded;
    }

    public void setAlreadyDead(){
        isAlreadyDeaded = true;
    }

    public bool getAlreadyDead(){
        return isAlreadyDeaded;
    }

    public float getHPRatio(){
        return currentHealth/maxHealth;
    }

    public void SetHPFull(){
        IncreaseHealth(maxHealth);
    }
}
