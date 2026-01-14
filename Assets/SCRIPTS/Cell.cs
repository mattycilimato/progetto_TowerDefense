using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer cellRender;
    public Color hoverColor;

    public void HoverStart()
    {
        cellRender.color = hoverColor;
    }
    public void HoverEnd()
    {
        cellRender.color = new Color(0, 0, 0, 0);

    }
}
