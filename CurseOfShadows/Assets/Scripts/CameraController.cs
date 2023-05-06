using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;
    public float maxDistance = 10f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > maxDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
