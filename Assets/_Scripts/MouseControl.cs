using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MouseControl : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;

    Vector3 mousePosition;
    [SerializeField] float moveSpeed = 0.1f;
    Vector2 position = new Vector2(0f, 0f);
    Vector2 screenBounds;
    float objectWidth;
    float objectHeight;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) / 2;
        objectWidth = spriteRenderer.bounds.size.x / 2;
        objectHeight = spriteRenderer.bounds.size.y / 2;
        Debug.Log($"ScreenBounds { screenBounds }, width { objectWidth }, height { objectHeight }");

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, - screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        mousePosition.y = Mathf.Clamp(mousePosition.y, - screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        rigidbody2d.MovePosition(position);
    }
}
