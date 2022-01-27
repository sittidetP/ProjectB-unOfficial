using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void Damage(float amount);

    void Damage(float amount, int attackedDirection);
}
