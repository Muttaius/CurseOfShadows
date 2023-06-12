using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
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
}

 