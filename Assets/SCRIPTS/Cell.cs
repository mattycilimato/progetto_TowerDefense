using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer cellRender;
    public Color hoverColor;

    TowerBase tower;
    public bool HasTower => tower != null;

    public void HoverStart()
    {
        cellRender.color = hoverColor;
    }
    public void HoverEnd()
    {
        cellRender.color = new Color(0, 0, 0, 0);

    }

    public void InsertTowerOnSell(TowerBase _tower)
    {
        tower = _tower;
    }

    
}
