using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //starting health of the attached enemy
    public int EnemystartingHealth;


    public int currentHealth;

    private void Awake()
    {
        //setting health when spawned
        currentHealth = EnemystartingHealth;
    }
    //function that modifies heath
    public void ChangeHealth(int Damage)
    {

        //changes health
        currentHealth = currentHealth + Damage;

        //sets minimum hp to 0
        currentHealth = Mathf.Clamp(currentHealth, 0, EnemystartingHealth);



        //plays Kill() enemy when 0 hp
        if (currentHealth == 0);
        {

            Kill();
        }

    }
    //destroys enemy
    public void Kill()
    {
        Destroy(gameObject); 
    }

    

}
