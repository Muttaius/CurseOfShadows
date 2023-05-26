//Coded by Keith Morrison 26/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{

    //Condition - when sword hits, do damage to enemy
    public int Damage = 0; //damage caused to enemy
    void OnTriggerEnter2D(Collider2D othercollider)
    {
        //checks for tag on object
        if (othercollider.CompareTag("Enemy") == true)
        {
            //Do damage
            DamageEnemy(othercollider.gameObject);
        }
    }

    public void DamageEnemy(GameObject enemy) //script to damage enemy
    {
        //enemy.TakeDamage(Damage);     
    }


}
