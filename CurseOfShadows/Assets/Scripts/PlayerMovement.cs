using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physicsBody = null;
    public float jumpSpeed = 10;
    public Collider2D groundSensor = null;
    public LayerMask groundLayer = 0;

    private void Awake()
    {
        physicsBody = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        Vector2 newVelocity = physicsBody.velocity;
        //set our new velocity to move in negative x (left) direction
        newVelocity.x = -1;
        physicsBody.velocity = newVelocity;
    }

    public void MoveRight()
    {
        Vector2 newVelocity = physicsBody.velocity;
        //set our new velocity to move in negative x (right) direction
        newVelocity.x = +1;
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
    void Update()
    {
        
    }
}
