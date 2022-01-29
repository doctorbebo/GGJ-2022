using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrust = 30;
    public float rotationSpeed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.AddForce(Vector3.left * thrust * 10);

        if (Random.Range(0, 2) == 0)
            rotationSpeed *= -1;

        rb.AddTorque(rotationSpeed);
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
