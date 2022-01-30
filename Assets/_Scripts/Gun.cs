using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  [SerializeField] GameObject bulletPrefab;

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
      bullet.transform.parent = transform;
      bullet.GetComponent<Polarity>().setPolarity(transform.parent.GetComponent<Polarity>().getPolarity());
    }
  }
}
