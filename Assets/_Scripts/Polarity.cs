using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarity : MonoBehaviour {
  [SerializeField] private int currentPolarity = PolarityStates.WHITE;
  public event Action<int> OnPolarityChanged;


  public void setPolarity(int newPolarity) {
    currentPolarity = newPolarity;
    OnPolarityChanged?.Invoke(newPolarity);
  }

  public int getPolarity() {
    return currentPolarity;
  }
}
