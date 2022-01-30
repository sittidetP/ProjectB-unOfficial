using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Weapon[] weapons;

    int indexWeapon = 0;

    public Weapon getSelectedWeapon(){
        return weapons[indexWeapon];
    }
}
