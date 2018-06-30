using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
// controles:
// movimiento: w,a,s,d
// atacar: click izquierdo del mous 
// espacio: saltar.

public class PlayerController : MonoBehaviour
{
    private bool moving;
    protected Rigidbody rig;
    public GameObject swordPlayer;
    private float timerDesactivationSword;
    private float timerActivationSword;
    private float timerShook;
    bool enabledAttack = false;
    public float speed;
    private float life;
    private bool shook;
    public Enemy01 enemigo01;
    public float damage;// force es la cantidad de daño que le hara al enemigo
    private float vertical;
    private float horizontal;
    private float distanceShook;
    public float speedJump;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        life = 100;
        timerDesactivationSword = 0.5f;
        timerActivationSword = 0.5f;
        timerShook = 0.1f;
        shook = false;
        distanceShook = 12;
    }

    void Update()
    {
        if (!shook)
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        if (timerDesactivationSword > 0)
        {
            timerDesactivationSword = timerDesactivationSword - Time.deltaTime;
        }
        if (timerDesactivationSword <= 0)
        {
            swordPlayer.SetActive(false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            //Attack();
            enabledAttack = true;
        }
        if (enabledAttack)
        {
            timerActivationSword = timerActivationSword - Time.deltaTime;
        }
        if (timerActivationSword <= 0)
        {
            Attack();
            timerActivationSword = 0.5f;
            enabledAttack = false;
        }
        if (shook)
        {
            timerShook = timerShook - Time.deltaTime;
            if (timerShook <= 0)
            {
                timerShook = 0.1f;
                shook = false;
                transform.Translate(0, 0, 0);
                
            }
        }
    }

    private void Move()
    {
        vertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, vertical*speed);
        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal, 0);
    }
    private void Jump()
    {
        rig.AddForce(new Vector3(0, speedJump, 0), ForceMode.VelocityChange);
    }
    private void Attack()
    {
            
        swordPlayer.SetActive(true);
        timerDesactivationSword = 0.5f;
    }
    public float GetDamage()
    {
        return damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            life = life - enemigo01.GetDamage();
            //transform.Translate(0, 0, ((vertical + distanceShook) * speed)* -1);
            rig.AddForce(-Vector3.forward, ForceMode.Impulse);
            Debug.Log("Vida Jugador:"+life);
            if (life <= 0)
            {
                //Debug.Log("GameOver");
                SceneManager.LoadScene("Game Over");
                //aqui deberia de cambiar de esena.
            }
        }
    }
}
