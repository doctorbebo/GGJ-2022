using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleMover : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        float thrust = Random.Range(25f, 35f);
        rb.AddForce(Vector3.left * thrust * 10);

        float rotationSpeed = Random.Range(-10f, 10f);

        rb.AddTorque(rotationSpeed);
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
