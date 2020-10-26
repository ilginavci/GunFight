using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{

    public float objectPosX, maxposY, minposY;
    private float startPosX, startPosY;
    private bool beingHeld = false;
    public float cooldown, cooldownMax;
    public GameObject bullet,bullet2,bullet3;
    public Transform spawnPoint, caseSpawnpoint;
    private Animator animator;
    public int playerDamage;
    public float health;
    public float animMultiplier;
    private AudioSource audioSource;
    public float power;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Multiplier", animMultiplier);
        bullet.GetComponent<BulletManager>().playerDamage = playerDamage;
    }

    void Update()
    {

        if (beingHeld == true)
        {

            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            if (mousepos.y < maxposY && mousepos.y > minposY)
            {
                this.gameObject.transform.localPosition = new Vector3(objectPosX, mousepos.y, 0);
            }
            if (cooldown <= 0)
            {
                cooldown = cooldownMax;
                Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
                Instantiate(bullet2, spawnPoint.transform.position, Quaternion.identity);
                Instantiate(bullet3, spawnPoint.transform.position, Quaternion.identity);
                animator.SetTrigger("Shoot"); //SHOOTING ANIM
                audioSource.Play(); //SHOOTING SOUND
                BulletCase();// BulletCase falling
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            startPosY = mousepos.y - this.transform.localPosition.y;

            beingHeld = true;
        }


    }

    private void OnMouseUp()
    {
        beingHeld = false;
    }
    public void GetDamage(float enemyDamage)
    {
        health -= enemyDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void BulletCase()
    {
        GameObject instentiated = Instantiate(bullet, caseSpawnpoint.transform.position, Quaternion.identity) as GameObject;
        Destroy(instentiated.GetComponent<BulletManager>());
        Destroy(instentiated.GetComponent<TrailRenderer>());
        instentiated.GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(instentiated, 3);
    }
}
