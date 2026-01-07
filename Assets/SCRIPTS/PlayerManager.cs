using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public UiManager uiManager;
    public int maxHp = 10;
    int currentHp = 10;

    public void Awake()
    {
        currentHp = maxHp;
    }

    public void PlayerHit(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            //TOOO : HAndle game over screen when the player die 
        }
        uiManager.UpdatePlayerHp(currentHp);    
    }
}
