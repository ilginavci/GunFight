using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public bool directionUp;
    public float maxposY, minposY;
    public GameObject enemyBullet;
    public float cooldown, cooldownMax;
    public Transform spawnPoint,caseSpawnpoint;
    private Animator animator;
    [SerializeField]
    private float health;
    public float animMultiplier;
    private AudioSource audioSource;


    void Start()
    { //Random Movement
        InvokeRepeating("RandomMovement", 0, 5);
        //Animation
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetFloat("Multiplier", animMultiplier);
        

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
    public void RandomMovement()
    {
        print("Random");
        var randomNumber = (Random.value > 0.5f); // it gives a bool , 1 or 0
        if (randomNumber)
        {
            directionUp = true; 
          
        }
        else
        {
            directionUp = false;
        }
    }
    public void GetDamage()
    {
        audioSource.Play();
        health -= 20;
        if (health <= 0)
        {
            Destroy(gameObject);
            //Changing Screen
            GameObject.Find("ScreenLine").GetComponent<Animator>().SetTrigger("ScreenAnim"); //ScreenLineAnimation
            GameObject.Find("Main Camera").GetComponent<ScreenManager>().ChangeScreen();// Camera background color
        }

    }
    public void EnemyFire()  // Bullet Fire and timing
    {
        if (cooldown <= 0)
        {
            cooldown = cooldownMax;
            Instantiate(enemyBullet, spawnPoint.transform.position, Quaternion.identity);
            BulletCase();
            animator.SetTrigger("Shoot");
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void BulletCase()
    {
        GameObject instentiated = Instantiate(enemyBullet, caseSpawnpoint.transform.position, Quaternion.identity) as GameObject;
        Destroy(instentiated.GetComponent<BulletManager>());
        Destroy(instentiated.GetComponent<TrailRenderer>());
        instentiated.GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(instentiated, 3);
    }
}
