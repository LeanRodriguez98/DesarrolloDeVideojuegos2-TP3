using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemy01 : MonoBehaviour {

    // Use this for initialization
    public TargetCollider targetCollider;
    public float life;
    public float damage;
    public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy();

        if(targetCollider != null)
        if(targetCollider.isTarget == true)
        Movement();
    }


    public void Destroy()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void Movement()
    {
        transform.LookAt(new Vector3 (PlayerController.instancie.transform.position.x, transform.position.y,PlayerController.instancie.transform.position.z));
        transform.position += transform.forward * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SwordPlayer")
        {           
            life -= PlayerController.instancie.damage;                
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instancie.life -= damage;
        }
    }

}
