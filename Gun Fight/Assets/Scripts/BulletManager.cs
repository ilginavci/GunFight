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

    void Start()
    {
        spriteRend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        defaultSprite = spriteRend.sprite;

        StartCoroutine(FlashMuzzle());
        

        bulletRB = this.GetComponent<Rigidbody2D>();
          // Player bullet goes right, Enemy bullet goes left
        if (gameObject.CompareTag("PlayerBullet"))
        {
            bulletRB.AddForce(Vector2.right * power);
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
                other.GetComponent<Player>().GetDamage();
            }
            else if(colliderTag == "Enemy")
            {
                other.GetComponent<Enemy>().GetDamage();
                
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
