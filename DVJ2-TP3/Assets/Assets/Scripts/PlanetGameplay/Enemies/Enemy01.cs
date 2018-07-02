using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy {

    private Animator animator;
    private char state;
    void Start()
    {
        animator = GetComponent<Animator>();
        state = 'I';
    }
	void Update () {
        Destroy();

        if (targetCollider != null)
        {
            if (targetCollider.isTarget == true)
            {
                if (state == 'I')
                {
                    animator.SetFloat("Speed", 1);
                }
                Movement();
                
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
            PlayerController.instancie.life -= damage;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (state == 'A')
        {
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Attack");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetFloat("Speed", 0);
    }

}
