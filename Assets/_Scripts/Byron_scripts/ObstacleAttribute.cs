using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObsticalAttr", menuName = "byron/Obstacle")]
public class ObstacleAttribute : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed => speed;
}
