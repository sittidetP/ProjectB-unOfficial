using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootPos;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] float idleTime;
    [SerializeField] int facingDiraction;
    private float startIdleTime;
    private bool isShoot;
    // Start is called before the first frame update
    void Start()
    {
        startIdleTime = Time.time;
        if(transform.rotation.y == 1){
            facingDiraction *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShoot && Time.time > startIdleTime + idleTime){
            GameObject _projectile =  GameObject.Instantiate(projectile, shootPos.position, projectile.transform.rotation);
            Projectile projectileScript = _projectile.GetComponent<Projectile>();
            projectileScript.SetUpProjectile(facingDiraction, whatIsPlayer, gameObject.layer);
            isShoot = true;
            startIdleTime = Time.time;
        }else{
            isShoot = false;
        }
    }
}
