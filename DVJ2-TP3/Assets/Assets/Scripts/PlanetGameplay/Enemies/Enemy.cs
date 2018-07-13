using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public TargetCollider targetCollider;
    public GameObject[] DropPickUps;
    public int DropProbability;
    public float life;
    public float damage;
    public float speed;

    private int DropItem;

    public void Destroy()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            DropItem = Random.Range(0, 99);
            if (DropItem <= DropProbability)
            {
                Instantiate(DropPickUps[Random.Range(0, DropPickUps.Length)], transform.position, Quaternion.identity);
            }
        }

    }

    public void Movement()
    {
        transform.LookAt(new Vector3(PlayerController.instancie.transform.position.x, transform.position.y, PlayerController.instancie.transform.position.z));
        transform.position += transform.forward * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SwordPlayer")
        {
            life -= PlayerController.instancie.damage;
        }

       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "m_HealArea")
        {
            life++; ;
        }
    }

}
