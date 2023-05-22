using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physicsBody = null;
    public float speed = 2;
    public Collider2D groundSensor = null;
    public LayerMask groundLayer = 0;
    public float jumpSpeed = 10;

    private void Awake()
    {
        physicsBody = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        Vector2 newVelocity = physicsBody.velocity;
        //set velocity to move in -x (left) direction
        newVelocity.x = -speed;
        physicsBody.velocity = newVelocity;
    }

    public void MoveRight()
    {
        Vector2 newVelocity = physicsBody.velocity;
        //set velocity to move in +x (right) direction
        newVelocity.x = +speed;
        physicsBody.velocity = newVelocity;
    }

    public void Jump()
    {
        if (groundSensor.IsTouchingLayers(groundLayer))
        {
            Vector2 newVelocity = physicsBody.velocity;
            newVelocity.y = jumpSpeed;
            physicsBody.velocity = newVelocity;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        // Get rigidbody from our player & check speed
        Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();

        float currentspeedH = ourRigidbody.velocity.x;
        float currentspeedV = ourRigidbody.velocity.y;

        // Get the animator
        Animator ourAnimator = GetComponent<Animator>();

        // Tell animator what the speeds are
        ourAnimator.SetFloat("speedH", currentspeedH);
        ourAnimator.SetFloat("speedV", currentspeedV);

    }
}

