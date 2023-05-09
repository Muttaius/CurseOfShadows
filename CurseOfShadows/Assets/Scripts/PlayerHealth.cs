//Coded by Keith Morrison 09/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Starting health for the player
    public int startingHealth;

    // Player's current health
    private int currentHealth;

    public string targetScene = "";

    void Awake()
    {
        // Initialise our current health to be equal to our 
        // starting health at the beginning of the game
        currentHealth = startingHealth;
    }

    // This function is NOT built in to Unity
    // It will only be called manually by our own code
    // It must be marked "public" so our other scripts can access it
    // This function will change the health value of the player
    public void ChangeHealth(int changeAmount)
    {
        // Take our current health, add the change amount, and store the result back in the current health variable
        currentHealth = currentHealth + changeAmount;

        // We don't want our current health to go below zero
        // And we don't want it to go above our starting health
        // So we use the special "Clamp" function to keep it 
        // between 0 and our starting health
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        // If our health has dropped to 0, that means our player should die.
        if (currentHealth == 0)
        {
            // We call the Kill function to kill the player
            Kill();
        }
    }



    // This function will kill the player
    public void Kill()
    {
        // Send player back to scene
        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }

    // This simple function will let other scripts ask this one what the current health is
    // the function RETURNS an integer, meaning it gives a number back to the code that called it
    public int GetHealth()
    {
        return currentHealth;
    }

    // This simple function will let other scripts ask this one what the max health is
    // the function RETURNS an integer, meaning it gives a number back to the code that called it
    public int GetMaxHealth()
    {
        return startingHealth;
    }

}