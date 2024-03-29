using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //Public variables for editing in unity editor

    public float forceStrength; // how fast the enemy will move

    public Vector2 direction;   //direction enemy will move in


    //Private variables
    private Rigidbody2D enemyRigidBody; //container for enemy rigid body

    // Awake is called when the script is first loaded
    void Awake()
    {

        //Get and store rigidbody for movement
        enemyRigidBody = GetComponent<Rigidbody2D>();

        //normalise direction, changing it to b length 1 to be used later
        direction = direction.normalized;

    }


    // Update is called once per frame
    void Update()
    {
        //Move in direction with forcestrength
        enemyRigidBody.velocity = direction * forceStrength;

        ///Added by Keith Morrison to detect speed of sprite movement
        // Get rigidbody from our player & check speed
        Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();

        float currentspeedH = ourRigidbody.velocity.x;

        // Get the animator
        Animator ourAnimator = GetComponent<Animator>();

        // Tell animator what the speeds are
        ourAnimator.SetFloat("speedH", currentspeedH);

    }
}

