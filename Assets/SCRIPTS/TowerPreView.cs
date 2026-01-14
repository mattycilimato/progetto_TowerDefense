using UnityEngine;

public class TowerPreView : MonoBehaviour
{
    public SpriteRenderer rangeRenderer;
    public SpriteRenderer towerRenderer;

    Color startingRangeColor;
    Color startingTowerColor;

    private void Awake()
    {
        startingRangeColor = rangeRenderer.color;
        startingTowerColor = towerRenderer.color;
    }

    public void PulseRed()
    {
        rangeRenderer.color = Color.red;

    }
}
