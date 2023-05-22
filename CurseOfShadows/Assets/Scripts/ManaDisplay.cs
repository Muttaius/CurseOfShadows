//Coded by Keith Morrison 09/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaDisplay : MonoBehaviour
{

    Slider ManaBar; //this will contain the slider component attached to this object

    PlayerMana player; //player mana component.

    // Start is called before the first frame update
    void Start()
    {
        ManaBar = GetComponent<Slider>(); //Getting the Slider component of this game object, and storing it in the healthBar variable.

        player = FindObjectOfType<PlayerMana>(); // Search the entire scene for the PlayerHealth component and store it in player variable.
    }

    // Update is called once per frame
    void Update()
    {
        //Temp float variables to use float division.
        float currentMana = player.GetMana();
        float maxMana = player.startingMana;


        //slider value should be between 0 & 1. 0 = empty, 1 = full
        ManaBar.value = currentMana / maxMana;
    }
}