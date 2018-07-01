using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    private Vector3 Direction;
    public GameObject ExplotionParticles;
    public float TimeOfLife;
    public float targetHeight;
    public float SpellSpeed;
    public float SpawnHeight;
    public float damage;

    // Use this for initialization
    void Start () {
        Direction.x = transform.position.x;
        Direction.y = transform.position.y + SpawnHeight;
        Direction.z = transform.position.z;
        transform.position = Direction;
        Direction.x = PlayerController.instancie.transform.position.x;
        Direction.y = PlayerController.instancie.transform.position.y + targetHeight;
        Direction.z = PlayerController.instancie.transform.position.z;
        transform.LookAt(Direction);

        Destroy(gameObject, TimeOfLife);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * SpellSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instancie.life -= damage;
            Instantiate(ExplotionParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
