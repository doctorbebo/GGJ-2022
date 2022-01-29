using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Polarity))]
public class PolarityChangeListener : MonoBehaviour {
  private Polarity polarity;

  void Awake() {
    polarity = GetComponent<Polarity>();
    InputManager.PolarityChanged += OnPolarityChanged;
  }

  void OnPolarityChanged() {
    int newPolarity = (polarity.getPolarity() + 1) % PolarityStates.STATES.Length;

    polarity.setPolarity(newPolarity);
  }
}
