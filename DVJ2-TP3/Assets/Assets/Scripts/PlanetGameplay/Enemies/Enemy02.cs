using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : Enemy {
    public GameObject Arrow;
    private Animator animator;
    public float ShootTimer;
    public float ShootHeight;
    private float AuxShootTimer;
    private Quaternion ArrowShootDirection;
    private float delay;
    void Start()
    {
        delay = 0;
        animator = GetComponent<Animator>();
        AuxShootTimer = ShootTimer;
        ArrowShootDirection.x = transform.position.x;
        ArrowShootDirection.y = transform.position.y + ShootHeight;
        ArrowShootDirection.z = transform.position.z;
        ArrowShootDirection.w = Quaternion.identity.w;
    }

    void Update () {
        Destroy();
        if(delay > 0)
        {
            delay-=Time.deltaTime;
        }
        //animator.SetFloat("Speed", 0);
        if (targetCollider != null)
        {
            if (targetCollider.isTarget == true)
            {
                if (ShootTimer >= 0)
                {
                    Movement();
                }
                Shoot();
            }
>>>>>>> master
    }

    public void Shoot()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer <= 0)
        {
            delay = 1;
            animator.SetBool("idle", false);
            animator.SetBool("Attacking", true);
            animator.SetBool("Runing", false);
            Instantiate(Arrow, transform.position, ArrowShootDirection);
            
            ShootTimer = AuxShootTimer;
        }
    }
}

                if (ShootTimer >= 0)
                {
                    Movement();
<<<<<<< HEAD
                    if (delay <= 0)
                    {
                        animator.SetBool("idle", false);
                        animator.SetBool("Attacking", false);
                        animator.SetBool("Runing", true);

                    }
                }
                Shoot();

            }
            else
            {
                animator.SetBool("idle", true);
                animator.SetBool("Attacking", false);
                animator.SetBool("Runing", false);
            }
        }
        
        
=======