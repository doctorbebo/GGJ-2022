using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Damagable : MonoBehaviour {
  private GameObject damageSpritePrefab;
  public Sprite damageSprite;
  public int health = 5;
  private int currentHealth;
  private float damageScaleFactor = 1f;
  Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
  int colorIndex = 0;

  [SerializeField] float damageDistance = 0.03f;
  [SerializeField] int numDamageSprites = 7;

  void Awake() {
    damageSpritePrefab = Resources.Load("Damage Sprite Prefab") as GameObject;
    currentHealth = health;
  }

  public void Damage() {
    currentHealth -= 1;

    if (currentHealth <= 0) {
      Destroy(gameObject);
    }
    damageSpritePrefab.GetComponent<SpriteRenderer>().sprite = damageSprite;
    for (int i = 0; i < numDamageSprites; i++) {
      Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f));
      GameObject go = Instantiate(damageSpritePrefab, transform.position + Vector3.forward, transform.rotation * rotation, transform);

      float damageScaling = 1f + ((health - currentHealth) / (float) health) * damageScaleFactor;
      float scaleFactor = 1f - ((transform.localScale.x - ObstacleSpawner.minScale) / (ObstacleSpawner.maxScale - ObstacleSpawner.minScale) / 2);

      Vector2 velocity = Quaternion.Euler(0f, 0f, 360 / numDamageSprites * i) * Vector2.up * damageDistance * scaleFactor * damageScaling;
      go.GetComponent<DamageSprite>().Init(colors[colorIndex++ % colors.Length], velocity);
    }
  }
}
