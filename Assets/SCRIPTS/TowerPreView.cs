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

    public void setPreview(Sprite towerSprite, float rangeScale)
    {
        towerRenderer.sprite = towerSprite;
        rangeRenderer.transform.localScale = new Vector3(rangeScale, rangeScale, 1);
    }


    public void PulseRed()
    {
        rangeRenderer.color = Color.red;

    }
}
