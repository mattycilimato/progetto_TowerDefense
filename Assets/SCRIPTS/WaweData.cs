using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaweData 
{
    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    public int enemiesAmount;
    public float totalSpawnTime = 6;

    public BaseEnemy GetRandomEnemy()
    {
        int randomEnemyindex = UnityEngine.Random.Range(0, enemies.Count - 1);
        return enemies[randomEnemyindex];
    }

    public float GetSpawnRateTime()
    {
        return totalSpawnTime / enemiesAmount;




    }

}
