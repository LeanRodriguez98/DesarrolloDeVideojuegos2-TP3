using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DVJ02.Clase08
{
public class AnimatorControlledPlayer : MonoBehaviour
{
    private Animator animator;
    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
 
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetFloat("Speed", Mathf.Abs(vertical));

            //animator.SetFloat("Speed", 1); si vale 1 camina
            //animator.SetFloat("Speed", 0); si vale 0 se queda quieto

            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
            }
    }
}
}
