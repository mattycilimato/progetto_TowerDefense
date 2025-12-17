using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
   public  Rigidbody2D body2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float Speed = 20f;
    LevelManager levelManager;
    int targetPathIndex = 0;
    public bool IsSideSpriteFacingRight;



    private void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }


    public void Update()
    {
        Vector3 targetPosition = levelManager.pathPoints[targetPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            if(targetPathIndex + 1 < levelManager.pathPoints.Count)
            {
                targetPathIndex++;
            }
            
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = (levelManager.pathPoints[targetPathIndex].position - transform.position).normalized;
        body2D.linearVelocity = direction * Speed;


        animator.SetFloat("Normalized_SpeedX", direction.x);
        animator.SetFloat("Normalized_SpeedY", direction.y);
        
        if(IsSideSpriteFacingRight )
        {
            spriteRenderer.flipX = (direction.x < 0);
        }
        else
        {
            spriteRenderer.flipX = (direction.x > 0);
        }
        
    }
}
