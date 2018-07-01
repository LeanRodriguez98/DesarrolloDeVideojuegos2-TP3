using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : Enemy {
    public GameObject Spell;
    public GameObject HealArea;
    public TargetCollider HealCollider;
    public float HealAreaTimer;
    public float ShootTimer;
    public float ShootHeight;
    private float AuxShootTimer;
    private Quaternion SpellShootDirection;
    private float OriginalHealTimer;
    // Use this for initialization
    void Start () {
        AuxShootTimer = ShootTimer;
        SpellShootDirection.x = transform.position.x;
        SpellShootDirection.y = transform.position.y + ShootHeight;
        SpellShootDirection.z = transform.position.z;
        SpellShootDirection.w = Quaternion.identity.w;
        OriginalHealTimer = HealAreaTimer;
    }
	
	// Update is called once per frame
	void Update () {
        Destroy();

        if (targetCollider != null)
            if (targetCollider.isTarget == true)
            {
                if (ShootTimer >= 0)
                    Movement();
                    Shoot();
            }
        Heal();
    }

    public void Shoot()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer <= 0)
        {
            Instantiate(Spell, transform.position, SpellShootDirection);
            ShootTimer = AuxShootTimer;
        }
    }

    public void Heal()
    {
        HealAreaTimer -= Time.deltaTime;
        if (HealCollider.isTarget == true && HealAreaTimer <= 0)
        {
            Instantiate(HealArea, transform.position, Quaternion.identity);
            HealAreaTimer = OriginalHealTimer;
        }
    }
}
