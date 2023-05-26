//Coded by Keith Morrison 26/05/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float lifespan; //number of seconds attack projectile lasts

    private float startTime; //timestamp that timer begins

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //Time.time = current timestamp (time since game started)
    }

    // Update is called once per frame
    void Update()
    {
        float endTime; //declare end timestamp for comparisons
 
        endTime = startTime + lifespan; 

        if (Time.time >= endTime)
        {
            //destroy object
            Destroy(gameObject);
        }
    }
}
