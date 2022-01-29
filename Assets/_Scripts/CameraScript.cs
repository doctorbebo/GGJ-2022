using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
  public Dictionary<int, Color> polarityMap = new Dictionary<int, Color> {
    { PolarityStates.WHITE, Color.black },
    { PolarityStates.BLACK, Color.white }
  };
  private Camera camera;

  void Awake() {
    InputManager.PolaritySwitched += PolaritySwitched;
    camera = GetComponent<Camera>();
  }

  void PolaritySwitched(int newPolarity) {
    camera.backgroundColor = polarityMap[newPolarity];
  }
}
