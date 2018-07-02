using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordEnemy : MonoBehaviour
{
    public Enemy01 enemy01;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DAÑO EFECTUADO");
        PlayerController.instancie.life -= enemy01.damage;
        PlayerController.instancie.TimeOfInvulnerability = 0;
    }
}
