//Coded by Keith Morrison 07/06/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSwordAttack : MonoBehaviour
{

    //Unity editor variables
    public GameObject skeletonSwordPrefab;
    public PlayerDetector sensor;
    public Vector2 projectileVelocity; //made public to change as and when required.
    public Vector3 detectorOffset;/// public variable to be added for offset 
    public Vector3 attackOffset;
    public float cooldown = 3.0f; //cooldown on weapon attack
    private float cooldownTimer = 0.0f;
    private bool isCooldown = false;


    

    private void Update()
    {

        if (sensor.playerDetected) //check if player detected
        {

            EnemyMovement HoldPosition = GetComponent<EnemyMovement>(); //stop sprite from continuing to move towards left of screen
            if (HoldPosition != null)
            {
                HoldPosition.enabled = false;
                //HoldPosition.forceStrength = 0; //sets force of sprite movement to 0
                //HoldPosition.direction = Vector2.zero; //sets direction of sprite movement to 0
            }

            Rigidbody2D gravity = GetComponent<Rigidbody2D>(); //gravity checker on rigidbody on death to stop enemy sprite falling through level.

            if (gravity != null) //checks drag on rigidbody
            {
                float currentspeedH = gravity.velocity.x;
                Animator enemyAnimator;
                enemyAnimator = GetComponent<Animator>();
                enemyAnimator.SetFloat("speedH", 0);
            }

            if (isCooldown)
            {

                ApplyCooldown(); //applies cooldown script on enemy attack

            }
            else
            {
                //have detected but not in cooldown
                SkeletonAttack();
            }



        }

        else
        {

            EnemyMovement HoldPosition = GetComponent<EnemyMovement>(); //stop sprite from continuing to move towards left of screen
            if (HoldPosition != null)
            {
                HoldPosition.enabled = true;
            }
        }

    }


    void ApplyCooldown()
    {
        //subtract time since last called
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0.0f) //when cooldown is at 0 changes isCooldown bool value
        {
            isCooldown = false; //removes cooldown by changing bool to false
        }

        else
        {
            //cooldown is true
        }

    }

    public void SkeletonAttack()
    {
        if (!isCooldown) //if isCooldown is false allows enemy to attack
        {
            //clone projectile
            GameObject clonedProjectile;

            //Command to clone projectile and keep result in variable
            clonedProjectile = Instantiate(skeletonSwordPrefab);

            //position projectile on player
            clonedProjectile.transform.position = transform.position + attackOffset;

            //Direction of attack - always to the right
            Rigidbody2D projectileRigidbody;

            //Get rigid body from the cloned object
            projectileRigidbody = clonedProjectile.GetComponent<Rigidbody2D>();


            //Play attack animation
            Animator enemyAnimator;
            enemyAnimator = GetComponent<Animator>();
            enemyAnimator.SetTrigger("attack");

            isCooldown = true; //changes bool value to isColldown to true
            cooldownTimer = cooldown; //sets time for cooldownTimer based on public variable
        }

    }






}
