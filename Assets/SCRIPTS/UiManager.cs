using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI playerHptext;

    public void UpdatePlayerHp(int playerHp)
    {
        playerHptext.text = playerHp.ToString();    
    }
}
