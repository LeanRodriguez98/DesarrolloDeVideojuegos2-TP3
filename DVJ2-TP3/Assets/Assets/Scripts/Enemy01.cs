using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour {

    // Use this for initialization
    public PlayerController player;
    private float life = 100;
    public float damage;
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SwordPlayer")
        {
            Debug.Log("Vida Enemigo"+life);
            life = life - player.GetDamage();// segun la fuerza del player es la vida que le sacara al enemigo
             Debug.Log("Vida Enemigo:"+life);
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public float GetDamage()
    {
        return damage;
    }
    public float GetSpeed()
    {
        return speed;
    }

}
