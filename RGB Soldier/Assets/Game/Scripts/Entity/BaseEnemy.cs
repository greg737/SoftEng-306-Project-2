﻿using UnityEngine;
using System.Collections;
using System;

// Enforces these modules to be loaded up with this module when placed on a prefab/game object
[RequireComponent(typeof(EntityMovement))]

public class BaseEnemy : KillableEntityInterface {

    public EntityMovement entityMovement;
    public int damageGiven = 1;
    public int count = 0;

	// Use this for initialization
	void Start () {
        this.entityMovement = GetComponent<EntityMovement>();
        InvokeRepeating("takeDamage(1)", 5f, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        AIControl();
        if (count++ == 400)
        {
            takeDamage(1);
        }
    }

     protected virtual void AIControl()
    {
         float velocity = 1.0f;

         //Moving left so invert velocity
        if(!entityMovement.facingRight)
        {
            velocity *= -1;
        }

        entityMovement.Movement(velocity);
    }

    private void OnCollisionEnter2D(Collision2D coll)
     {
        //Hit side wall so reverse direction of movement
        if(coll.gameObject.CompareTag("SideWall"))
        {
            entityMovement.Flip();
        }
     }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Take damage trigger function
        if (other.gameObject.CompareTag("PlayerEnemyCollider"))
        {
            Player player = other.GetComponentInParent<Player>();
            player.takeDamage(damageGiven);
        }
    }

    public override void takeDamage(int damageReceived)
    {
        if (currentHealth-damageReceived <= 0) {
            die();
        }
       
    }

    public override void die()
    {
        dead = true;
        Destroy(gameObject, 2f);
    }
}
