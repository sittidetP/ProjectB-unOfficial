using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreProjectile : MonoBehaviour
{
    [SerializeField] protected float projectileVelocity;
    [SerializeField] protected float damageAmount;
    [SerializeField] protected float destroySelfTime = 10f;
    protected LayerMask whatIsDamagable; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
