﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public bool directionUp;
    public float maxposY, minposY;
    public GameObject enemyBullet;
    public float cooldown, cooldownMax;
    public Transform spawnPoint;
    private Animator animator;
    public float enemyDamage;
    bool isDead = false;
    public float health;
    public float animMultiplier;
    private AudioSource audioSource;
    private GameObject[] cards;

    void Start()
    { //Random Movement
        InvokeRepeating("RandomMovement", 0, 5);
        //Animation
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetFloat("Multiplier", animMultiplier);
        enemyBullet.GetComponent<BulletManager>().enemyDamage= enemyDamage;
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
    public void GetDamage(float playerDamage)
    {
        //    audioSource.Play();
        health -= playerDamage;
        GameObject.Find("StageManager").GetComponent<StageManager>().healthbar.fillAmount = health / 100;
        if (health <= 0)
        {
            CheckBossDead();
            Destroy(gameObject);
            if (!isDead)
            {
                TinySauce.OnGameFinished(PlayerPrefs.GetInt("Stage"));
                GameObject.Find("StageManager").GetComponent<StageManager>().NextEnemy();    
               //Changing Screen
                GameObject.Find("ScreenLine").GetComponent<Animator>().SetTrigger("ScreenAnim"); //ScreenLineAnimation
                GameObject.Find("Main Camera").GetComponent<ScreenManager>().ChangeScreen();// Camera background color  
                isDead = true;
               
            }
          
        }

    }
    public void EnemyFire()  // Bullet Fire and timing
    {
        if (cooldown <= 0)
        {
            cooldown = cooldownMax;
            Instantiate(enemyBullet, spawnPoint.transform.position, Quaternion.identity);

            if ( audioSource != null)
            {
                audioSource.Play();
            }

            animator.SetTrigger("Shoot");
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }


    private void CheckBossDead()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
        if (gameObject.GetComponent<Boss>() != null)
        {
            GameObject.Find("StageManager").GetComponent<StageManager>().canRespawn = false;
            Debug.Log("BOSS OLDU");
            cards[0].GetComponent<Animator>().SetTrigger("PullCards");
            cards[1].GetComponent<Animator>().SetTrigger("PullCards");
            cards[2].GetComponent<Animator>().SetTrigger("PullCards");
        }
    }
}
