using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public bool directionUp;
    public float maxposY, minposY;
    public bool random;
    public GameObject enemyBullet;
    public float cooldown, cooldownMax;
    public Transform spawnPoint;

    void Start()
    { //Random Movement
        InvokeRepeating("RandomMovement", 0, 5);
    }
    void FixedUpdate()
    {   //Enemy Movement
        if (directionUp)
        { 
            transform.Translate(Vector2.up * enemySpeed * Time.fixedDeltaTime);
            if(transform.position.y > maxposY)
            {
                directionUp = !directionUp;
            }
        }
    else
        {
            transform.Translate(Vector2.down * enemySpeed * Time.fixedDeltaTime);
            if (transform.position.y < minposY)
            {
                directionUp = !directionUp;
            }
        } 
        // Bullet Fire and timing
        if (cooldown <= 0)
        {
           cooldown = cooldownMax;
          Instantiate(enemyBullet, spawnPoint.transform.position, Quaternion.identity);

        }
        else
        {
          cooldown -= Time.deltaTime;
        }
    }
    void RandomMovement()
    {
        var randomNumber = (Random.value > 0.5f); // it gives a bool , 1 or 0
        if (randomNumber)
        {
            directionUp = false; 
            random = true;
        }
        else
        {
            directionUp = true;
            random = true;
        }
    }


}
