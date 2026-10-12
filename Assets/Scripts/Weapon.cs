using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private Animator animator;
    private float cooldown = 0.4f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

//        if (Input.GetKey(KeyCode.Mouse0))
//        {
//            if (Time.time - lastSwing > cooldown)
//            {
//                lastSwing = Time.time;
//                Swing();
//            }
//        }
    }

    protected override void onCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }

            // Create new damage object, then send it to fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecieveDamage", dmg);
        }
    }

    public void Swing()
    {
        if (Time.time - lastSwing > cooldown)
        {
            lastSwing = Time.time;
            animator.SetTrigger("Swing");

        }

    }
}
