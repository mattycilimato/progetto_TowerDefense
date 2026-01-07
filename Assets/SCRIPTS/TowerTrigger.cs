using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    List<BaseEnemy> enemyInView = new List<BaseEnemy>();

    public List<BaseEnemy> GetEnemyInViews()
    {
        return enemyInView; 
    }
    public bool IsEnemyInView()
    {
        return enemyInView.Count > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if(enemy != null )
            {
                enemyInView.Add(enemy); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemyInView.Remove(enemy);
            }
        }
    }
}
