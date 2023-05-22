//Coded by Keith Morrison 22/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMana : MonoBehaviour
{
    // Starting mana for the player
    public int startingMana;

    // Player's current mana.
    private int currentMana;


    void Awake()
    {
        // starting health at the beginning of the game
        currentMana = startingMana;
    }

    // Allows other scripts ask this one what the current health is
    public int GetMana()
    {
        return currentMana;
    }

    // Allows other scripts to know what the max health is
    public int GetMaxMana()
    {
        return startingMana;
    }

}