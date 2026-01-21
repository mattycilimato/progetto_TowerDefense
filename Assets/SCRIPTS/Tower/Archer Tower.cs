using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : TowerBase
{
    public override void Shoot()
    {
        List<BaseEnemy> enemiesInView = trigger.GetEnemyInViews();
        int biggerPahtindex = -1;
        BaseEnemy target = null;
        foreach (BaseEnemy enemy in enemiesInView)
        {
            if (enemy.TargetPathIndex > biggerPahtindex)
            {
                biggerPahtindex = enemy.TargetPathIndex;
                target = enemy;
            }
        }
        if (target != null)
        {
            target.Hit(damage);
        }




        Debug.Log("Bang");
    }
}
