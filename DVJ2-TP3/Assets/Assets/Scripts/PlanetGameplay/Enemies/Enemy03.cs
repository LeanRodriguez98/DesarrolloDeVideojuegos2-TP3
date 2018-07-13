using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : Enemy {
    public GameObject Spell;
    public GameObject HealArea;
    public TargetCollider HealCollider;
    public float HealAreaTimer;
    public float ShootTimer;
    public float ShootHeight;
    private float AuxShootTimer;
    private Quaternion SpellShootDirection;
    private float OriginalHealTimer;
    private Animator animator;
    public float delay;
    private bool first;
    private float auxDelay;
    // Use this for initialization
    void Start () {
        first = true;
        auxDelay = delay;
        delay = 0;
        AuxShootTimer = ShootTimer;
        ShootTimer = 0;
        SpellShootDirection.x = transform.position.x;
        SpellShootDirection.y = transform.position.y + ShootHeight;
        SpellShootDirection.z = transform.position.z;
        SpellShootDirection.w = Quaternion.identity.w;
        OriginalHealTimer = HealAreaTimer;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Destroy();
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        if (targetCollider != null)
        {
            if (targetCollider.isTarget == true)
            {
                Shoot();

                if (ShootTimer >= 0 && delay <= 0)
                {
                    Movement();
                    Debug.Log("Corriendo");
                    animator.SetBool("Attack", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("run", true);
                }
            }
            else
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", true);
                animator.SetBool("run", false);
                first = true;
            }
            
        }
        Heal();
    }

    public void Shoot()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer <= 0)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Idle", false);
            animator.SetBool("run", false);
            Instantiate(Spell, transform.position, SpellShootDirection);
            delay = auxDelay;
            Debug.Log("Atacando");
            if (first)
            {
                delay = 0;
                first = false;
            }
            ShootTimer = AuxShootTimer;
        }
        else
        { 
            
        }
    }

    public void Heal()
    {
        HealAreaTimer -= Time.deltaTime;
        if (HealCollider.isTarget == true && HealAreaTimer <= 0)
        {
            Instantiate(HealArea, transform.position, Quaternion.identity);
            HealAreaTimer = OriginalHealTimer;
        }
    }
}
