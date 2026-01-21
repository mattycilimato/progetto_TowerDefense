using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour
{
    [Header("settings")]
    public LayerMask raycastLayer;

    [Header("Componets")]
    public TowerPreView towerPreView;
    public PlayerManager playerManager;

    [Header("Prefab")]
    public ArcherTower archerTower;
    public CannonTower cannonTower;
    

    Cell currentHoverCell;

    bool IsBuildingTower;
    int buildTowerIndex = -1;

    private void Awake()
    {
        towerPreView.gameObject.SetActive(false);
    }






    public void Update()
{
      Vector2 viewMousePos = Mouse.current.position.value;
      Vector2 worldMousePos =  Camera.main.ScreenToWorldPoint(viewMousePos);


      RaycastHit2D hit =  Physics2D.Raycast(worldMousePos, Vector2.zero, 500, raycastLayer);


        if(hit.collider != null)
        {
            Cell cell = hit.collider.transform.GetComponent<Cell>();
            if(cell != null && cell != currentHoverCell)
            {
                
                
                
                    ResetHover();
               
                
                    cell.HoverStart();
                
                
                currentHoverCell = cell; 
            }
        }
        else
        {
            ResetHover();
            towerPreView.gameObject.SetActive(false);
        }
        if (IsBuildingTower && currentHoverCell != null)
        {
            towerPreView.transform.position = currentHoverCell.transform.position;
            if(currentHoverCell.HasTower)
                towerPreView.gameObject.SetActive(false);
            else
                towerPreView.gameObject.SetActive(true);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && currentHoverCell != null)
        {
            
            if (IsBuildingTower && !currentHoverCell.HasTower)
            {
                TowerBase towerToBuild = GetTowerToBuild();
                




                if (playerManager.SpendMoney(towerToBuild.cost))
                {
                    Vector3 pos = currentHoverCell.transform.position;
                    TowerBase newTower = Instantiate(towerToBuild, pos, Quaternion.identity, currentHoverCell.transform);
                    currentHoverCell.InsertTowerOnSell(newTower);
                }
                else
                {
                    //Mostrare che non hai i soldi
                }
            }
            

           
            
            
            
            
            
            
            
        }
    }

    
    TowerBase GetTowerToBuild()
    {
       
        if (buildTowerIndex == 0)
        {
            return archerTower;
        }
        else if (buildTowerIndex == 1)
        {
            return cannonTower;
        }
        else
        {
            
            Debug.LogError("LA TORRE CHE VUOI NON ESISTE");
            return archerTower;
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

    public void EventButton_BuildTower(int towerIndex)
    {
        if(buildTowerIndex == towerIndex)
        {
            IsBuildingTower = false;
        }
        else
        {
            IsBuildingTower = true;
            buildTowerIndex = towerIndex;
            TowerBase towerToBuild = GetTowerToBuild();
            towerPreView.setPreview(towerToBuild.GetTowerSprite(),towerToBuild.range * 2);
        }
    }



}
