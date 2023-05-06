using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public int maxEnemies = 10; // The maximum number of enemies to spawn
    public float spawnInterval = 15f; // The interval between enemy spawns

    private float timer; // A timer to track when to spawn the next enemy

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // If the timer has reached the spawn interval and there are fewer than the maximum number of enemies
        if (timer >= spawnInterval && GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            // Spawn a new enemy at this object's position
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // Reset the timer
            timer = 0f;
        }
    }

    //To use this script, attach it to an empty GameObject in your scene and set the enemyPrefab variable to the prefab of the enemy you want to spawn.
    //You can adjust the maxEnemies and spawnInterval variables to control the maximum number of enemies and the time between spawns, respectively.

    //Make sure to tag your enemies with the "Enemy" tag so the script can correctly count how many enemies are currently in the scene.
    //You can do this by selecting an enemy in your scene, clicking on the "Tag" dropdown in the Inspector, and selecting "Add Tag". Then, type "Enemy" in the "Tag" field and click the "+" button to create the tag.
    //Finally, select the "Enemy" tag for all of your enemy GameObjects.
}
