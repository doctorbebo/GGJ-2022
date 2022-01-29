using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] float moveSpeed = 0.1f;
    Rigidbody2D rigidbody2d;
    Vector2 position = new Vector2(0f, 0f);
    Vector2 screenBounds;
    float objectWidth;
    float objectHeight;

    SpriteRenderer spriteRenderer;
    bool isWhiteSprite = true;
    [SerializeField] Sprite whiteSprite;
    [SerializeField] Sprite balckSprite;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = spriteRenderer.bounds.size.x / 2;
        objectHeight = spriteRenderer.bounds.size.y / 2;
        spriteRenderer.sprite = whiteSprite;
        isWhiteSprite = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, - screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        mousePosition.y = Mathf.Clamp(mousePosition.y, - screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        rigidbody2d.MovePosition(position);

        if (Input.GetMouseButtonDown(0))    // Left click
        {

        }
        if (Input.GetMouseButtonDown(1))    // Right click
        {
            if (isWhiteSprite)
            {
                spriteRenderer.sprite = balckSprite;
                isWhiteSprite = false;
            }
            else
            {
                spriteRenderer.sprite = whiteSprite;
                isWhiteSprite = true;
            }          
        }

    }

}

