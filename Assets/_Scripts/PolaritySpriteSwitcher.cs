using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Polarity))]
[RequireComponent(typeof(SpriteRenderer))]
public class PolaritySpriteSwitcher : MonoBehaviour {
  private Polarity polarity;
  private SpriteRenderer spriteRenderer;
  public Sprite[] sprites;

  void Awake() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    polarity = GetComponent<Polarity>();
    polarity.OnPolarityChanged += SwitchSprites;
  }

  void OnDestroy() {
    polarity.OnPolarityChanged -= SwitchSprites;
  }

  void SwitchSprites(int newPolarity) {
    spriteRenderer.sprite = sprites[newPolarity];
    spriteRenderer.sortingOrder = polarity.samePolaraityAsPlayer ? 1 : 0;
  }
}
