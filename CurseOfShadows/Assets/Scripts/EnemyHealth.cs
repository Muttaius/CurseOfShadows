using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //starting enemy health
    public int enemyHealth;

    //active interactable health
    int currentEnemyHealth;

    void Awake()
    {
        currentEnemyHealth = enemyHealth;
    }

    public void damage(int damageAmount)
    {
        enemyHealth = currentEnemyHealth - damageAmount;

        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, enemyHealth);
    
     if (enemyHealth == 0)
        {

            Kill();
        }
    
    }

    public void Kill()
    {
        Animator playerAnimator; //get player animator
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetTrigger("death"); //play death trigger animation
        GetComponent<CapsuleCollider2D>();
        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>(); //gets capsule collider so sprite when dead will allow player to walk over corpse without collision

        if (capsuleCollider != null) //check if capsule is present. 
        {
            Destroy(capsuleCollider.gameObject); //if present destroy collider
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
