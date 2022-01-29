using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
  public GameObject damageSpritePrefab;
  Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
  int colorIndex = 0;

  [SerializeField] float damageDistance = 0.03f;
  [SerializeField] int numDamageSprites = 7;

  void Awake() {
    InputManager.DamageShip += DamageShip;
  }

  void DamageShip() {
    for (int i = 0; i < numDamageSprites; i++) {
      GameObject go = Instantiate(damageSpritePrefab, transform.position + Vector3.forward, Quaternion.identity);
      go.transform.parent = transform;
      Vector2 velocity = Quaternion.Euler(0f, 0f, 360 / numDamageSprites * i) * Vector2.up * damageDistance;
      go.GetComponent<DamageSprite>().Init(colors[colorIndex++ % colors.Length], velocity);
    }
  }
}
