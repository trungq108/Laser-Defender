using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveConfig",menuName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float Speed;
    [SerializeField] float timeBettweenEnemySpawn = 1f;
    [SerializeField] float spawnTimeVarian = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public float GetSpeed()
    {
        return Speed;
    } 

    public Transform GetFirstWayPoint()
    {
        Transform firstWayPoint = pathPrefab.GetChild(0);
        return firstWayPoint;
    }

    public List<Transform> GetAllWayPoint()
    {
        List<Transform> wayPointList = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            wayPointList.Add(child);
        }
        return wayPointList;
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBettweenEnemySpawn - spawnTimeVarian, timeBettweenEnemySpawn + spawnTimeVarian);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        
    }
}
