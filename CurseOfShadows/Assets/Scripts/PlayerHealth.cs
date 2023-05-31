//Coded by Keith Morrison 09/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Starting health for the player
    public int startingHealth;

    // Player's current health.
    private int currentHealth;

    public string targetScene = "";

    //for adding audio files to health loss script
    public AudioClip[] audioOptions; 

    //loop checker for health audio scripts
    private bool hasPlayedAudio = false;

    void Awake()
    {
         // starting health at the beginning of the game
        currentHealth = startingHealth;
    }

    
    // Function will change the health value of the player
    public void ChangeHealth(int changeAmount)
    {
        // Take our current health, add the change amount, and store the result back in the current health variable
        currentHealth = currentHealth + changeAmount;

        // Prevents health going below 0 or above 100
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);


        //when player health is less than 75 or equal to or greater than 51 script runs
        // script loop halts if audio has already played once within this health threshold.
        if ((currentHealth == 75 || currentHealth >= 51) && !hasPlayedAudio)
        {
            int randomIndex = Random.Range(0, audioOptions.Length); //random generator to choose audio clip
            AudioSource.PlayClipAtPoint(audioOptions[randomIndex], transform.position);
            hasPlayedAudio = true; //when audio is played changes boolean value to true.
        }

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
        Animator playerAnimator; //get player animator
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetTrigger("death"); //play death trigger animation

        StartCoroutine(ChangeSceneWithDelay()); //calls function to delay changing scene
    }
    
    IEnumerator ChangeSceneWithDelay() //delays ChangeScene for 2 seconds to allow death animation to play
    {
            yield return new WaitForSeconds(2f); // yield used together with return keyword to provide a value to the enumerator object

        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene); //loads scene set in unity
    }

    // Allows other scripts ask this one what the current health is
    public int GetHealth()
    {
        return currentHealth;
    }

    // Allows other scripts to know what the max health is
    public int GetMaxHealth()
    {
        return startingHealth;
    }

}