//Coded by Keith Morrison 26/05/23
//and me CUZ IM COOL
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int Damage = 1; // Damage caused to enemy

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check for enemy tag on object
        if (otherCollider.CompareTag("Enemy"))
        {
            // Do damage
            DamageEnemy(otherCollider.gameObject);
        }
    }

    public void DamageEnemy(GameObject enemy) //doing damage script. 
    {
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        if (enemyBehaviour != null)
        {
            enemyBehaviour.TakeHit(Damage);
        }
    }
}

