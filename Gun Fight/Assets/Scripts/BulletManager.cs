using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    public float power;
    void Start()
    {   
        bulletRB = this.GetComponent<Rigidbody2D>();
          // Player bullet goes right, Enemy bullet goes left
        if (gameObject.CompareTag("PlayerBullet"))
        {
            bulletRB.AddForce(Vector2.right * power);
        }
        else
        {
            bulletRB.AddForce(Vector2.left * power);
        }
            Destroy(gameObject, 3); 
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {

    }
   
    
}
