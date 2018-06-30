using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAenemmy01 : MonoBehaviour {

    // Use this for initialization
    
    
    public Enemy01 enemy01;
    bool moverse;
    private float Xenemmy;
    private float Zenemmy;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (moverse)
        {
            Movimiento();
            enemy01.transform.position = new Vector3(Xenemmy, transform.position.y, Zenemmy);
        }
        //moverse = false;//comentar en caso que el movimiento sea raro
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            moverse = true;
        }
        
    }
    public bool GetMoverse()
    {
        return moverse;
    }
    private void Movimiento()
    {
        if (PlayerController.instancie.transform.position.x > enemy01.transform.position.x)
        {
            Xenemmy = Xenemmy + enemy01.GetSpeed() * Time.deltaTime;
            Debug.Log("+x");
        }
        if (PlayerController.instancie.transform.position.z > enemy01.transform.position.z)
        {
            Zenemmy = Zenemmy + enemy01.GetSpeed() * Time.deltaTime;
            Debug.Log("+z");
        }
        if (PlayerController.instancie.transform.position.x < enemy01.transform.position.x)
        {
            Xenemmy = Xenemmy - enemy01.GetSpeed() * Time.deltaTime;
            Debug.Log("-x");
        }
        if (PlayerController.instancie.transform.position.z < enemy01.transform.position.z)
        {
            Zenemmy = Zenemmy - enemy01.GetSpeed() * Time.deltaTime;
            Debug.Log("-z");
        }
        
    }
}
