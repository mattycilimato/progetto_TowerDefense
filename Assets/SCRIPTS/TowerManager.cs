using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour
{
    [Header("settings")]
    public LayerMask raycastLayer;

    Cell currentHoverCell;

    public void Update()
{
      Vector2 viewMousePos = Mouse.current.position.value;
      Vector2 worldMousePos =  Camera.main.ScreenToWorldPoint(viewMousePos);


      RaycastHit2D hit =  Physics2D.Raycast(worldMousePos, Vector2.zero, 500, raycastLayer);


        if(hit.collider != null)
        {
            Cell cell = hit.collider.transform.GetComponent<Cell>();
            if(cell != null )
            {
                cell.HoverStart();
                if(cell != currentHoverCell)
                {
                    ResetHover();
                }
                currentHoverCell = cell; 
            }
        }
        else
        {
            ResetHover();   
        }
    }

    void ResetHover()
    {
        if (currentHoverCell != null)
        {
            currentHoverCell.HoverEnd();
            currentHoverCell = null;
        }
    }

}
