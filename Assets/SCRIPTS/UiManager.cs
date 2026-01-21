using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI playerHptext;
    public TextMeshProUGUI playerMoneytext;
   
    public List<TowerButton> towerButtons = new List<TowerButton>();
    

    public void UpdatePlayerHp(int playerHp)
    {
        playerHptext.text = playerHp.ToString();    
    }

    public void UpdatePlayerMoney(int playerMoney)
    {
        playerMoneytext.text = playerMoney.ToString();
        
        foreach(TowerButton tb in towerButtons)
        {

            if (playerMoney >= tb.towerBase.cost)
            {
                tb.SetInteractable(true);
            }
            else
            {
                tb.SetInteractable(false);
            }
        }
        
        
        
        
        
    }
}
