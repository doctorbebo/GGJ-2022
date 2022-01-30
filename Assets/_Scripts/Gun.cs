using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  [SerializeField] GameObject bulletPrefab;
  AudioSource bulletSFX;

    private void Awake()
    {
        bulletSFX = GetComponent<AudioSource>();
    }

    void Update() {
    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
      GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
      bullet.transform.parent = transform;
      bullet.GetComponent<Polarity>().setPolarity(transform.parent.GetComponent<Polarity>().getPolarity());

      if (bulletSFX != null)
         bulletSFX.Play();
    }
  }
}
