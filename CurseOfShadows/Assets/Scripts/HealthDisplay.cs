//Coded by Keith Morrison 09/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{

    Slider healthBar; //slider component

    PlayerHealth player; //player health component.

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>(); //Getting the Slider component of this game object, and storing it in the healthBar variable.

        player = FindObjectOfType<PlayerHealth>(); // Search the entire scene for the PlayerHealth component and store it in player variable.
    }

    // Update is called once per frame
    void Update()
    {
        //Temp float variables to use float division.
        float currentHealth = player.GetHealth();
        float maxHealth = player.startingHealth;


        //slider value should be between 0 & 1. 0 = empty, 1 = full
        healthBar.value = currentHealth / maxHealth;
    }
}
