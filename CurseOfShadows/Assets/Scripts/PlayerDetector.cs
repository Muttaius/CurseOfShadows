//Coded by Keith Morrison 07/06/23
//Script designed to detect if player is present within PlayerDetector prefab to trigger attacks of enemies.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{

    public bool playerDetected = false;
    public Vector3 offset;


    public void OnTriggerEnter2D(Collider2D collision) //set as public so other scripts can access information
    {
        
        if (collision.CompareTag("Player")) //checks tag, if player change value to true and trigger attack
        { 
            playerDetected = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision) //set as public so other scripts can access information
    {

        if (collision.CompareTag("Player")) 
        {
            playerDetected = false; //if no player detected, will not trigger enemy to attack.
        }
    }




}
