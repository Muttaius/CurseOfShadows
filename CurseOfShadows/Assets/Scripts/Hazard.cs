//coded by Keith Morrison 12/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    //Amount of damage this enemy does
    public int hazardDamage;


    // Collider with player character
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Get the object we collided with
        Collider2D objectWeCollidedWith = collisionData.collider;

        // Get the PlayerHealth script attached to that object
        PlayerHealth player = objectWeCollidedWith.GetComponent<PlayerHealth>();

        //Will only trigger if a player character, not damage other enemies
        if (player != null)
        {
            //damage to player
            player.ChangeHealth(-hazardDamage);
        }
    }
}