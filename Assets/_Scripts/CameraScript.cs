using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Polarity))]
public class CameraScript : MonoBehaviour {
  public Dictionary<int, Color> polarityMap = new Dictionary<int, Color> {
    { PolarityStates.WHITE, Color.white },
    { PolarityStates.BLACK, Color.black }
  };
  private Camera camera;
  private Polarity polarity;

  void Awake() {
    camera = GetComponent<Camera>();
    polarity = GetComponent<Polarity>();
    polarity.OnPolarityChanged += ChangeBackgroundColor;
  }

  void OnDestroy() {
      polarity.OnPolarityChanged -= ChangeBackgroundColor;
    }

    void ChangeBackgroundColor(int newPolarity) {

    if(camera == null || camera.Equals(null))
        camera = GetComponent<Camera>();

    camera.backgroundColor = polarityMap[newPolarity];
  }
}
