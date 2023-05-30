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
        enemyHealth = currentEnemyHealth + damageAmount;

        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, enemyHealth);
    
     if (enemyHealth == 0)
        {

            Kill();
        }
    
    }

    public void Kill()
    {
        Destroy(gameObject);

    }
}
