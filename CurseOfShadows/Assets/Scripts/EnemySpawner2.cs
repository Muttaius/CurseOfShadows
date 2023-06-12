using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform spawnPoint; // The transform representing the spawn point

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Spawn a new enemy at the spawn point's position
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}