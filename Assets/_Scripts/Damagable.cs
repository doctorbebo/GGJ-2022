using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Damagable : MonoBehaviour {
  private SpriteRenderer spriteRenderer;
  private Collider2D collider;
  private GameObject damageSpritePrefab;
  public Sprite damageSprite;
  public int maxHealth = 5;
  public int currentHealth;
  private float damageScaleFactor = 1f;
  Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
  int colorIndex = 0;
  public bool alive;

  [SerializeField] float damageDistance = 0.03f;
  [SerializeField] int numDamageSprites = 7;

  void Awake() {
    damageSpritePrefab = Resources.Load("Damage Sprite Prefab") as GameObject;
    currentHealth = maxHealth;
    spriteRenderer = GetComponent<SpriteRenderer>();
    collider = GetComponent<Collider2D>();
    alive = true;
  }

  public void Damage() {
    currentHealth -= 1;

    if (currentHealth <= 0) {
      alive = false;
      spriteRenderer.enabled = false;
      collider.enabled = false;
      Destroy(gameObject, 2);
    }
    damageSpritePrefab.GetComponent<SpriteRenderer>().sprite = damageSprite;
    for (int i = 0; i < numDamageSprites; i++) {
      Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f));
      GameObject go = Instantiate(damageSpritePrefab, transform.position + Vector3.forward, transform.rotation * rotation, transform);

      float damageScaling = 1f + ((maxHealth - currentHealth) / (float) maxHealth) * damageScaleFactor;
      float scaleFactor = 1f - ((transform.localScale.x - ObstacleSpawner.minScale) / (ObstacleSpawner.maxScale - ObstacleSpawner.minScale) / 2);

      Vector2 velocity = Quaternion.Euler(0f, 0f, 360 / numDamageSprites * i) * Vector2.up * damageDistance * scaleFactor * damageScaling;
      go.GetComponent<DamageSprite>().Init(colors[colorIndex++ % colors.Length], velocity);
    }
  }
}
