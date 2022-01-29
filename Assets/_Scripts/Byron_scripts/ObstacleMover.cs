using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleMover : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust = 30;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.AddForce(Vector3.left * thrust * 10);
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
