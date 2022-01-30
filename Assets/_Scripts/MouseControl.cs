using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Damagable))]
public class MouseControl : MonoBehaviour {
  private Rigidbody2D rigidbody2d;
  private SpriteRenderer spriteRenderer;
  private Damagable damagable;

  [SerializeField] float moveSpeed = 0.1f;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    rigidbody2d = GetComponent<Rigidbody2D>();
    damagable = GetComponent<Damagable>();
  }

  void OnCollisionEnter2D(Collision2D collision) {
    damagable.Damage();
    Destroy(collision.gameObject);
  }

  void Update() {
    Camera camera = Camera.main;
    Vector2 cameraBounds = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
    Vector2 spriteDimensions = spriteRenderer.bounds.size / 2;
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    mousePosition.x = Mathf.Clamp(mousePosition.x, - cameraBounds.x + spriteDimensions.x, cameraBounds.x - spriteDimensions.x);
    mousePosition.y = Mathf.Clamp(mousePosition.y, - cameraBounds.y, cameraBounds.y);

    rigidbody2d.MovePosition(Vector2.Lerp(transform.position, mousePosition, moveSpeed));
  }
}
