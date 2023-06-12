using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int Damage = 1; // Damage caused to enemy

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check for enemy tag on object
        if (otherCollider.CompareTag("Player"))
        {
            // Do damage
            DamagePlayer(otherCollider.gameObject);
        }
    }

    public void DamagePlayer(GameObject player) //doing damage script. 
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ChangeHealth(Damage);
        }
    }
}


