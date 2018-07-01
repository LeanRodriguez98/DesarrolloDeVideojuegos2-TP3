using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : Enemy {
    public GameObject Arrow;
   
    public float ShootTimer;
    public float ShootHeight;
    private float AuxShootTimer;
    private Quaternion ArrowShootDirection;
    void Start()
    {
        
        AuxShootTimer = ShootTimer;
        ArrowShootDirection.x = transform.position.x;
        ArrowShootDirection.y = transform.position.y + ShootHeight;
        ArrowShootDirection.z = transform.position.z;
        ArrowShootDirection.w = Quaternion.identity.w;
    }

    void Update () {
        Destroy();

        if (targetCollider != null)
            if (targetCollider.isTarget == true)
            {
                if(ShootTimer>=0)
                Movement();
                Shoot();
            }
    }

    public void Shoot()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer <= 0)
        {
            Instantiate(Arrow, transform.position, ArrowShootDirection);
            ShootTimer = AuxShootTimer;
        }
    }
}
