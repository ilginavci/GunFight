using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    public float power;
    public string colliderTag;
    private Sprite defaultSprite;
    public Sprite muzzleSprite;
    private SpriteRenderer spriteRend;
    public int flashframetime;
    [HideInInspector]public int playerDamage, enemyDamage;

    void Start()
    {
        spriteRend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        defaultSprite = spriteRend.sprite;

        StartCoroutine(FlashMuzzle());
        

        bulletRB = this.GetComponent<Rigidbody2D>();
          // Player bullet goes right, Enemy bullet goes left
        if (gameObject.CompareTag("PlayerBullet"))
        {
            bulletRB.AddForce(transform.right * power);
            BulletDeviation();
        }
        else
        {
            bulletRB.AddForce(Vector2.left * power);
            BulletDeviation();
        }
            Destroy(gameObject, 3); 
        
    
    }
    void BulletDeviation()
    {
        var randomNumber = (Random.value > 0.5f); // it gives a bool , 1 or 0
        if (randomNumber)
         {
            bulletRB.AddForce(Vector2.up * power / 20);
        }
        
    }
    void OnTriggerEnter2D (Collider2D other )
    { 
        if(other.gameObject.CompareTag(colliderTag))
        {
            Destroy(gameObject);
            if (colliderTag == "Player")
            {
                if(other.GetComponent<Player>() != null)
                {
                    other.GetComponent<Player>().GetDamage(enemyDamage);
                }
                if(other.GetComponent<ShotGun>() != null)
                {
                    other.GetComponent<ShotGun>().GetDamage(enemyDamage);

                }
            }

            else if(colliderTag == "Enemy")
            {
                other.GetComponent<Enemy>().GetDamage(playerDamage);
                
            }
        }
    }
   

   IEnumerator FlashMuzzle()
    {
        spriteRend.sprite = muzzleSprite;
        for (int i =0; i < flashframetime; i++)
        {
            
            yield return 0;
        }
        spriteRend.sprite = defaultSprite;
    }


}
