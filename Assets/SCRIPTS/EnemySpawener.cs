using System.Collections.Generic;
using UnityEngine;

public class EnemySpawener : MonoBehaviour
{
    public LevelManager LevelManager;
    public List<WaweData> waweDatas = new List<WaweData>(); 
     float waweTimer = 0;
    public float waweWaitTime = 10;
    bool isSpawnig = false;
    bool IsWAitingNextWawe = true;
    int enemisWaweSpawned;



    int currentWaweIndex = 0;
    List<BaseEnemy> spawnedEnemies = new List<BaseEnemy>();
    float spawnRateTime = 10f;
    float spawnRateTimer = 0;
    public void Update()
    {
        if (IsWAitingNextWawe)
        {
            waweTimer += Time.deltaTime;
            if(waweTimer > waweWaitTime)
            {
                
                IsWAitingNextWawe=false;
               
                isSpawnig = true;
                StartWawe();
            }
        }

        if (isSpawnig && enemisWaweSpawned < waweDatas[currentWaweIndex].enemiesAmount)
        {
            spawnRateTimer += Time.deltaTime;
            if(spawnRateTimer > spawnRateTime)
            {
                spawnRateTimer = 0;

                BaseEnemy enemyToSpawn = waweDatas[currentWaweIndex].GetRandomEnemy();
                BaseEnemy newEnemy = Instantiate(enemyToSpawn, LevelManager.pathPoints[0].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                enemisWaweSpawned++;
            }

        }
    }

    void StartWawe()
    {
        
        spawnRateTime = waweDatas[currentWaweIndex].GetSpawnRateTime();
        spawnRateTimer = 0;
    }










}
