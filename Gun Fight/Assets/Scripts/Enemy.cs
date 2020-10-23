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
    private Animator animator;
    public float health;
    public float animMultiplier;

    void Start()
    { //Random Movement
        animator = GetComponent<Animator>();
        animator.SetFloat("Multiplier", animMultiplier);
        InvokeRepeating("RandomMovement", 0, 5);

    }
    void FixedUpdate()
    {   //Enemy Movement
        if (directionUp)
        { 
            transform.Translate(Vector2.up * enemySpeed * Time.fixedDeltaTime, Space.World);
            if(transform.position.y > maxposY)
            {
                directionUp = !directionUp;
            }
        }
    else
        {
            transform.Translate(Vector2.down * enemySpeed * Time.fixedDeltaTime, Space.World);
            if (transform.position.y < minposY)
            {
                directionUp = !directionUp;
            }
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
    public void GetDamage()
    {
        health -= 20;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void EnemyFire()  // Bullet Fire and timing
    {
        if (cooldown <= 0)
        {
            cooldown = cooldownMax;
            Instantiate(enemyBullet, spawnPoint.transform.position, Quaternion.identity);
            animator.SetTrigger("Shoot");
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

}
