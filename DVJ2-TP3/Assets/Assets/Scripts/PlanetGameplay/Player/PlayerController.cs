using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
// controles:
// movimiento: w,a,s,d
// atacar: click izquierdo del mouse
// espacio: saltar.

/*public class PlayerController : MonoBehaviour
{
    public static PlayerController instancie;
    private Animator animator;
    private bool moving;
    private Rigidbody rig;
    public GameObject swordPlayer;
    public float timerDesactivationSword;
    public float timerActivationSword;
    public float timerShook;
    bool enabledAttack = false;
    public float speed;
    public float life;
    private bool shook;
    public float damage;
    private float vertical;
    private float horizontal;
    public float distanceShook;
    public float speedJump;
    private float originalTimerActiationSword;
    private float originalTimerDesactiationSword;
    private bool activeInventory;
    void Start()
    {
        instancie = this;
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        originalTimerActiationSword = timerDesactivationSword;
        originalTimerDesactiationSword = timerDesactivationSword;
        shook = false;
        activeInventory = false;
    }*/

//=======
﻿/*using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;*/
// controles:
// movimiento: w,a,s,d
// atacar: click izquierdo del mouse
// espacio: saltar.

public class PlayerController : MonoBehaviour
{
    public static PlayerController instancie;
    private Animator animator;
    private bool moving;
    private Rigidbody rig;
    public GameObject swordPlayer;
    public float timerDesactivationSword;
    public float timerActivationSword;
    public float timerShook;
    private bool enabledAttack;
    public float speed;
    public float life;
    private bool shook;
    public float damage;
    private float vertical;
    private float horizontal;
    public float distanceShook;
    public float speedJump;
    private float originalTimerActiationSword;
    private float originalTimerDesactiationSword;
    private bool activeInventory;
    private char stateAnimation;
    private int StopSpeedAnimation;
    public float TimeOfInvulnerability;
    private float OriginalTimeOfInvulnerability;
    void Start()
    {
        instancie = this;
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        originalTimerActiationSword = timerDesactivationSword;
        originalTimerDesactiationSword = timerDesactivationSword;
        shook = false;
        activeInventory = false;
        StopSpeedAnimation = 0;
        enabledAttack = false;
        OriginalTimeOfInvulnerability = TimeOfInvulnerability;
    }

    void Update()
    {
        if (EventSystem.current != null)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                activeInventory = true;
                animator.SetFloat("Speed", 0);
                stateAnimation = 'I';
            }
            else
            {
                activeInventory = false;
            }
        }
        
        if (!activeInventory)
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
                stateAnimation = 'I';
            }

            if (Input.GetButtonDown("Fire1") && stateAnimation == 'I')
            {
                animator.SetTrigger("Attack");
                enabledAttack = true;
            }

            if (enabledAttack)
            {
                timerActivationSword = timerActivationSword - Time.deltaTime;
            }

            if (timerActivationSword <= 0)
            {
                Attack();
                timerActivationSword = originalTimerActiationSword;
                enabledAttack = false;
                animator.SetTrigger("Attack");
                animator.SetFloat("Speed", 0);
                stateAnimation = 'A';
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

            if (life <= 0)
            {
                SceneManager.LoadScene("Game Over");
                //Destroy(gameObject);
            }
        }

        if (TimeOfInvulnerability <= OriginalTimeOfInvulnerability)
        {
            TimeOfInvulnerability += Time.deltaTime;
        }
       
    }
    private void Attack()
    {
        swordPlayer.SetActive(true);
        timerDesactivationSword = originalTimerDesactiationSword;
        stateAnimation = 'A';
    }
    private void Move()
    {
        if (stateAnimation == 'I')
        {
            vertical = Input.GetAxis("Vertical");
            transform.Translate(0, 0, vertical * speed);
            horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, horizontal, 0);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetFloat("Speed", Mathf.Abs(vertical));
        }
    }
    private void Jump()
    {
        rig.AddForce(new Vector3(0, speedJump, 0), ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("m_Item"))
        {
            ItemPickup item = other.gameObject.GetComponent<ItemPickup>();
            item.PickUp();
        }
    }
    
}