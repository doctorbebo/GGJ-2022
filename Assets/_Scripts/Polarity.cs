using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarity : MonoBehaviour {
  private SpriteRenderer spriteRenderer;
  public Sprite[] sprites;

  void Awake() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    InputManager.PolaritySwitched += PolaritySwitched;
  }

  void PolaritySwitched(int newPolarity) {
    spriteRenderer.sprite = sprites[newPolarity];
  }
}
