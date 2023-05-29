//Coded by Keith Morrison 26/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{

    //Unity editor variables
    public GameObject swordPerfab;
    public Vector2 projectileVelocity; //made public to change as and when required.
    public Vector3 offset;/// public variable to be added for offset 
    public float cooldown = 3; //cooldown on weapon attack
    public float timer = 0f;


    private void Update()
    {
        if (timer <= 0f)
        {
            if (Time.time >= timer + cooldown)
            {
                SwordAttack();
                timer = cooldown; //start the cooldown timer
            }
            
        }

        else
        {
            timer -= Time.deltaTime;
        }

    }


    //Action - fire sword projectile
    public void SwordAttack()
    {
            //clone projectile
            GameObject clonedProjectile;

            //Command to clone projectile and keep result in variable
            clonedProjectile = Instantiate(swordPerfab);

            //position projectile on player
            clonedProjectile.transform.position = transform.position + offset;

            //Direction of attack - always to the right
            Rigidbody2D projectileRigidbody;

            //Get rigid body from the cloned object
            projectileRigidbody = clonedProjectile.GetComponent<Rigidbody2D>();

            //sets velocity on rigidbody
            projectileRigidbody.velocity = projectileVelocity;

            //Play MCSword attack animation
            Animator playerAnimator;

            //get animation already attached
            playerAnimator = GetComponent<Animator>();
            playerAnimator.SetTrigger("attack");
    }
            

    

}
