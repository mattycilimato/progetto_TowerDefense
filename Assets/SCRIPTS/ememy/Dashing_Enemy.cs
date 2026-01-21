using UnityEngine;

public class Dashing_Enemy : BaseEnemy
{
    [Header("Dashing Settings")]
    public float dashTime = 2;
    public float dashChargeTime = 2;
    public float dashSpeed = 10;


    private float startingSpeed;
    float timer = 0;
    bool IsDAshing = false;
   
    
    public override void Awake()
    {
        startingSpeed = Speed;
        
        base.Awake();
    }

    public override void Update()
    {
      timer += Time.deltaTime;
        if (!IsDAshing)
        {
            if(timer >= dashChargeTime)
            {
                Speed = dashSpeed;
                IsDAshing=true;
                timer = 0;
            }
        }
        if (IsDAshing)
        {
            if (timer >= dashTime)
            {
                Speed = startingSpeed;
                IsDAshing = false;  
                timer = 0;
            }
        }
        
        
        
        base.Update();
    }


    
    
    
    
    
   
}
