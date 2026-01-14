using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public UiManager uiManager;
    public int maxHp = 10;
    public int startingMoney = 10;
    int currentHp = 10;
    int money = 0;

    public void Awake()
    {
        currentHp = maxHp;
        uiManager.UpdatePlayerHp(currentHp);
        money = startingMoney;
        uiManager.UpdatePlayerMoney(money);
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

    public void GainMoney(int amount)
    {
        money += amount;
        uiManager.UpdatePlayerMoney(money);
    }
    public bool SpendMoney(int amount)
    {
        if (money < amount)
        {
            return false;
        }
       
        money -= amount;
        uiManager.UpdatePlayerMoney(money);
        return true;
    }
}
