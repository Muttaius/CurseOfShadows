using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject SkeletonSwordsman;
    public GameObject spawnPosition;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Instantiate(SkeletonSwordsman, spawnPosition.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}