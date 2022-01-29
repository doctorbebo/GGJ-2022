using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public string [] Tags;

    public UnityEvent CollisionEvent;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var tag in Tags)
        {
            if(collision.gameObject.CompareTag(tag))
            {
                CollisionEvent?.Invoke();
                break;
            }
        }
    }
}
