using UnityEngine;

public class Doge_Enemy : BaseEnemy
{
    [Header("Doge Settings")]
    public float dogeChancheNormalized = 0.2f;


    [Header("Doge Componet")]
    public GameObject missFeedBackPreFab;
    GameObject missFeedBack;
    public override void Hit(int damege)
    {
       float rand = Random.Range(0.0f, 1.0f);
        if(rand <= dogeChancheNormalized)
        {
           missFeedBack = Instantiate(missFeedBackPreFab, transform.position, Quaternion.identity, transform.parent);
            Invoke("DestroyFeedBack", 0.3f);
        }
        else
        {
            base.Hit(damege);
        }



            
    }


    void DestroyFeedBack()
    {
        if(missFeedBack != null)
        {
            Destroy(missFeedBack);
        }
    }
}
