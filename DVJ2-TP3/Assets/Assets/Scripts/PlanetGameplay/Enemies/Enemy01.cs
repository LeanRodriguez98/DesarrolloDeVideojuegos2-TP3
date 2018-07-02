using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy {
    private Animator animator;
    public GameObject swordEnemy;
    private float delayAttack;
    private char state;
    void Start()
    {
        animator = GetComponent<Animator>();
        state = 'I';
        swordEnemy.SetActive(false);
        delayAttack = 0;
    }
	void Update () {
        Destroy();
       
        if(delayAttack> 0)
        {
            delayAttack = delayAttack - Time.deltaTime;
            //swordEnemy.SetActive(true);
        }
        if (targetCollider != null)
        {
            if (targetCollider.isTarget == true)
            {
                if (state == 'I')
                {
                    animator.SetFloat("Speed", 1);
                    Movement();
                }
              
                
            }
            else
            {
                state = 'I';
                animator.SetFloat("Speed", 0);
            }
        }
    }    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            state = 'A';

            //PlayerController.instancie.life -= damage;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (state == 'A')
        {
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Attack");
            swordEnemy.SetActive(true);
            if(delayAttack<=0)
            {
                delayAttack = 1;
                swordEnemy.SetActive(false);
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetFloat("Speed", 0);
        state = 'I';
       
    }

}
