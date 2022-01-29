using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider))]
public class CollisionHandler : MonoBehaviour
{
    public string [] Tags;

    public UnityEvent<GameObject> CollisionEvent;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var tag in Tags)
        {
            if(collision.gameObject.CompareTag(tag))
            {
                CollisionEvent?.Invoke(collision.gameObject);
                break;
            }
        }
    }
}
