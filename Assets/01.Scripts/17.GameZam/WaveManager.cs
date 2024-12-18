using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingletone<WaveManager>
{
    [SerializeField] private GameObject meleeEnemyPrefab;
    [SerializeField] private GameObject rangedEnemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossPrefab2;
    [SerializeField] private GameObject bossPrefab3;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform bossSpawnpoint;

    [SerializeField] private List<Transform> trans = new List<Transform>();

    private int currentWave = 0;
    private int enemiesAlive = 0;

    private void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        currentWave++;
        Debug.Log($"{currentWave}웨이브 시작");

        int numberOfEnemies = currentWave; 

        if (currentWave % 5 == 0)
        {
            spawnPoint = bossSpawnpoint;
            if (currentWave == 5)
            {
                Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            }
            else if (currentWave == 10)
            {
                Instantiate(bossPrefab2, spawnPoint.position, Quaternion.identity);
            }
            else if (currentWave == 15)
            {
                Instantiate(bossPrefab3, spawnPoint.position, Quaternion.identity);
            }
            enemiesAlive = 1;
        }
        else
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                GameObject enemyToSpawn = Random.Range(0, 2) == 0 ? meleeEnemyPrefab : rangedEnemyPrefab;
                spawnPoint = trans[Random.Range(0, trans.Count)];
                Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
            }
            enemiesAlive = numberOfEnemies;
        }
    }

    public void EnemyDefeated()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            if (currentWave < 15) 
            {
                Debug.Log($"{currentWave}웨이브 끝");
                StartWave();
            }
            else
            {
                Debug.Log("모든 웨이브가 완료되었습니다!");
            }
        }
    }


}
