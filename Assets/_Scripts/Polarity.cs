using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarity : MonoBehaviour {
  private SpriteRenderer spriteRenderer;
  public Sprite[] sprites;
  private int polarity;

  void Awake() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    InputManager.PolaritySwitched += PolaritySwitched;
  }

  void PolaritySwitched(int newPolarity) {
    polarity = newPolarity;
    spriteRenderer.sprite = sprites[newPolarity];
  }

   public int GetPolarity() => polarity;
}


public static class PolarityExtension
{
    public static int? GetPolarity(this GameObject obj)
    {
        if (obj.TryGetComponent(out Polarity polarity))
            return polarity.GetPolarity();
        else
            return null;
    }
}
