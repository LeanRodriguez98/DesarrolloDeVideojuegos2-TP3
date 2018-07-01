using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy {


	void Update () {
        Destroy();

        if (targetCollider != null)
            if (targetCollider.isTarget == true)
                Movement();
    }    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instancie.life -= damage;
        }
    }

}
