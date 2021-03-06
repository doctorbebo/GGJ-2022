using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static ObstacleSpawner instance;
    public static float maxScale = 3f;
    public static float minScale = 0.25f;

    [Header("Obstacles will Spawn between these two values on the Y axis")]

    [Range(0, 25)]
    public float max;
    [Range(0, -25)]
    public float min;

    public float spawnXposition;

    [Space]

    public float spawnRate;
    private float timer;

    [Space]


    [Header("Obstacle Prefabs")]
    public GameObject[] obstacles;


    private void Awake() {
        timer = spawnRate;
    }

    private void Update() {
        if (timer < 0f) {
            timer = spawnRate;
            SpawnObstacle();
        } else {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnObstacle() {
        GameObject spawnObj = obstacles[Random.Range(0,obstacles.Length)];
        spawnObj = Instantiate(spawnObj, new Vector3(spawnXposition, Random.Range(min, max), 0), Quaternion.identity, transform);
        float scale = Random.Range(minScale, maxScale);
        timer += (scale - minScale) / (maxScale - minScale) * 3 * Time.deltaTime;
        spawnObj.transform.localScale = new Vector3(scale, scale, 1.0f);
        Damagable damagable = spawnObj.GetComponent<Damagable>();
        damagable.maxHealth = (int) (damagable.maxHealth * scale);
        // Rigidbody2D rigidbody = spawnObj.GetComponent<Rigidbody2D>();
        // rigidbody.mass *= scale;

        // Randomly select polarity for newly spawned PolarityChangingAsteroids
        if (spawnObj.GetComponent<PolarityChangeListener>() != null) {
          Polarity polarity = GetComponent<Polarity>();
          if (polarity != null) { // Not sure why these are occasionally null
            polarity.setPolarity(Random.Range(0, PolarityStates.STATES.Length));
          }
        }

        Destroy(spawnObj, 30);
    }

}
