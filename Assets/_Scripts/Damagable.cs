using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Damagable : MonoBehaviour {
  private GameObject damageSpritePrefab;
  public Sprite damageSprite;
  Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
  int colorIndex = 0;

  [SerializeField] float damageDistance = 0.03f;
  [SerializeField] int numDamageSprites = 7;

  void Awake() {
    damageSpritePrefab = Resources.Load("Damage Sprite Prefab") as GameObject;
    InputManager.CauseDamage += Damage;
  }

  void Damage() {
    damageSpritePrefab.GetComponent<SpriteRenderer>().sprite = damageSprite;
    for (int i = 0; i < numDamageSprites; i++) {
      GameObject go = Instantiate(damageSpritePrefab, transform.position + Vector3.forward, transform.rotation);
      go.transform.parent = transform;
      Vector2 velocity = Quaternion.Euler(0f, 0f, 360 / numDamageSprites * i) * Vector2.up * damageDistance;
      go.GetComponent<DamageSprite>().Init(colors[colorIndex++ % colors.Length], velocity);
    }
  }
}
