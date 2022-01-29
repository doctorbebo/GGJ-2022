using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static ObstacleSpawner instance;



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

    
    private void Awake()
    {
        //if (instance == null)
        //    instance = this;
        //else
        //    Destroy(this);

        timer = spawnRate;
    }

    private void Update()
    {
        if(timer < 0f)
        {
            timer = spawnRate;
            SpawnObstacle();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnObstacle()
    {
        GameObject spawnObj = obstacles[Random.Range(0,obstacles.Length)];
        spawnObj = Instantiate(spawnObj, new Vector3(spawnXposition, Random.Range(min, max), 0), Quaternion.identity, transform);
        Destroy(spawnObj, 30);
    }

}
