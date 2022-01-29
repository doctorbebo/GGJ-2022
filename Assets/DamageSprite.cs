using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageSprite : MonoBehaviour {
  public float speed = 1f;
  public float damping = 0.98f;
  public float cutoff = 0.001f;
  private SpriteRenderer spriteRenderer;
  private Vector2 acceleration;
  private Vector2 velocity;

  public void Init(Color color, Vector2 velocity) {
    spriteRenderer = GetComponent<SpriteRenderer>();

    spriteRenderer.color = color;
    this.velocity = velocity;
  }

  void Update() {
    transform.localPosition += (Vector3) velocity * speed;
    velocity -= (Vector2) (transform.localPosition) * transform.localPosition.sqrMagnitude * Time.deltaTime;
    velocity = velocity * damping;

    if (velocity.magnitude < cutoff && transform.localPosition.magnitude < (1 + cutoff)) {
      DestroyObject(gameObject);
    }
  }
}
