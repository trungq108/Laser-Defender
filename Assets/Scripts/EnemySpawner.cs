using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBettweenWave = 0f;
    WaveConfigSO currentWave;
    [SerializeField] bool isLooping;

    public WaveConfigSO GetCurrenWave()
    {
        return currentWave;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    IEnumerator SpawnEnemyWave()
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetFirstWayPoint().position, Quaternion.Euler(0,0,180), this.transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBettweenWave);
            }
        }
        while (isLooping);
        
    }
}
