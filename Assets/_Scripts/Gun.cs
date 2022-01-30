using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  [SerializeField] GameObject bulletPrefab;
  Damagable shipDamagable;
  AudioSource bulletSFX;

    private void Awake()
    {
        bulletSFX = GetComponent<AudioSource>();
        shipDamagable = transform.parent.gameObject.GetComponent<Damagable>();
    }

    void Update() {
      if (shipDamagable.alive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Polarity>().setPolarity(transform.parent.GetComponent<Polarity>().getPolarity());

        if (bulletSFX != null)
           bulletSFX.Play();
      }
    }
}
