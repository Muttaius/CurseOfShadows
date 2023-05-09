using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTipping : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Slope")
        {
            float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
            if (angle > capsuleCollider.transform.rotation.eulerAngles.z)
            {
                capsuleCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}