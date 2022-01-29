using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MouseControl : MonoBehaviour {
  private Rigidbody2D rigidbody2d;
  private SpriteRenderer spriteRenderer;
  public GameObject damageSpritePrefab;
  Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
  int colorIndex = 0;

  [SerializeField] float moveSpeed = 0.1f;
  [SerializeField] float damageDistance = 0.03f;
  [SerializeField] int numDamageSprites = 7;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  void Update() {
    Camera camera = Camera.main;
    Vector2 cameraBounds = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
    Vector2 spriteDimensions = spriteRenderer.bounds.size / 2;
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    mousePosition.x = Mathf.Clamp(mousePosition.x, - cameraBounds.x + spriteDimensions.x, cameraBounds.x - spriteDimensions.x);
    mousePosition.y = Mathf.Clamp(mousePosition.y, - cameraBounds.y + spriteDimensions.y, cameraBounds.y - spriteDimensions.y);

    rigidbody2d.MovePosition(Vector2.Lerp(transform.position, mousePosition, moveSpeed));

    if (Input.GetMouseButtonDown(0)) {
      for (int i = 0; i < numDamageSprites; i++) {
        GameObject go = Instantiate(damageSpritePrefab, transform.position + Vector3.forward, Quaternion.identity);
        go.transform.parent = transform;
        Vector2 velocity = Quaternion.Euler(0f, 0f, 360 / numDamageSprites * i) * Vector2.up * damageDistance;
        go.GetComponent<DamageSprite>().Init(colors[colorIndex++ % colors.Length], velocity);
      }
    }
  }
}
