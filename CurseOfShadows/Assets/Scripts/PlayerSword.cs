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
    public float cooldown = 5.0f; //cooldown on weapon attack
    private float cooldownTimer = 0.0f;
    private bool isCooldown = false;




    private void Update()
    {

        if (isCooldown)
        {

            ApplyCooldown(); //applies cooldown script making button unaccessable

        }

    }


    void ApplyCooldown()
    {
        //subtract time since last called
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f) //when cooldown is at 0 changes isCooldown bool value
        {
            isCooldown = false; //removes cooldown by changing bool to true

        }

    }

    public void SwordAttack()
    {
        if (!isCooldown) //if isCooldown is false allows button to be pressed.
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

            isCooldown = true; //changes bool value to isColldown to true
            cooldownTimer = cooldown; //sets time for cooldownTimer based on public variable




        }

    }



}
   
    
            

    


