using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthBarBehaviour HealthBar;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Kill();
        }
    }

    public void Kill() //death animation player
    {
        Animator enemyAnimator; //get enemy animator
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetTrigger("death"); //play death trigger animation

        Rigidbody2D gravity = GetComponent<Rigidbody2D>(); //gravity checker on rigidbody on death to stop enemy sprite falling through level.

        if (gravity != null) //checks gravity on rigidbody
        {
            float currentspeedH = gravity.velocity.x;
            enemyAnimator = GetComponent<Animator>();
            enemyAnimator.SetFloat("speedH", 0);
            gravity.gravityScale = 0;
        }

        EnemyMovement movement = GetComponent<EnemyMovement>(); //gets enemy movement script

        if (movement != null)
        {
            movement.forceStrength = 0; //sets force of sprite movement to 0
            movement.direction = Vector2.zero; //sets direction of sprite movement to 0
        }

        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>(); //gets capsule collider so sprite when dead will allow player to walk over corpse without collision

        if (capsuleCollider != null) //check if capsule is present. 
        {
            Destroy(capsuleCollider); //if present destroy collider
        }

        SkeletonSwordAttack noAttack = GetComponent<SkeletonSwordAttack>(); //destroys enemy attack on enemy death so enemy can't attack when dead.

        if (noAttack != null)
        {
            Destroy(noAttack);
        }

        StartCoroutine(DestroySpriteWithDelay());
    }

    IEnumerator DestroySpriteWithDelay()
    {

        yield return new WaitForSeconds(5f); //delay of sprite dead on ground before deleting object

        SpriteKill();

    }

    public void SpriteKill()

    {
        Destroy(gameObject);
    }
}