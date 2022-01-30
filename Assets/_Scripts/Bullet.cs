using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float speed = 20f;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject != transform.parent.parent.gameObject) {
        Destroy(gameObject);
        Destroy(collision.gameObject);
      }
    }

    void Update() {
      Camera camera = Camera.main;

      if (transform.position.x > (camera.orthographicSize * camera.aspect) / 2 + 10f) {
        Destroy(gameObject);
      }
    }
}
