using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("componet")]
    
    public  Rigidbody2D body2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collider2D enemyCollider2D;



    [Header("settings")]
    public float Speed = 20f;
    public int playerHitDamage =1;
    LevelManager levelManager;
    int targetPathIndex = 0;
    public bool IsSideSpriteFacingRight;
    public int MaxHp = 2;
    public int moneyReward = 2;
   
    
    
    int currentHp = 2;
    bool active = true;
    bool IsDead = false;
    public virtual void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        currentHp = MaxHp;
    }

    public int TargetPathIndex => targetPathIndex;
    

    public virtual void Update()
    {
        if (!active)
        {
            return;
        }
        
        Vector3 targetPosition = levelManager.pathPoints[targetPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            if(targetPathIndex + 1 < levelManager.pathPoints.Count)
            {
                targetPathIndex++;
            }
            else
            {
                TargetReached();
            }
            
        }
    }

    public void FixedUpdate()
    {
        if (!active)
        {
            return;
        }


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

    public void TargetReached()
    {
        active = false;
        enemyCollider2D.enabled= false;
        PlayerManager playerManager = FindFirstObjectByType<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.PlayerHit(playerHitDamage);
        }
        DestroyMe();
    }

    public virtual void Hit(int damege)
    {
        currentHp -= damege;
       spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);
        if(currentHp <= 0 && !IsDead)
        {
            IsDead = true;
            PlayerManager playermanager = FindFirstObjectByType<PlayerManager>();
            if (playermanager != null)
            {
                playermanager.GainMoney(moneyReward);
            }
            DestroyMe();
        }
    }

    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void DestroyMe()
    {
       EnemySpawener enemySpawener = FindFirstObjectByType<EnemySpawener>();
        if(enemySpawener != null)
        {
            enemySpawener.OnEnemyDie(this);
        }
        active = false;
        ;
        animator.SetBool("Dead", IsDead);
        Invoke("Despawn", 4f);
        
    }

    void Despawn()
    {
        Destroy(gameObject);
    }

}



