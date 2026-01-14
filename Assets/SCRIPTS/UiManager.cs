using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI playerHptext;
    public TextMeshProUGUI playerMoneytext;

    public void UpdatePlayerHp(int playerHp)
    {
        playerHptext.text = playerHp.ToString();    
    }

    public void UpdatePlayerMoney(int playerMoney)
    {
        playerMoneytext.text = playerMoney.ToString();
    }
}
