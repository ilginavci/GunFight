using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] players;
    public GameObject[] playerIndex;
    public Transform enemySpawnPoint, enemySpawnPointUp;
    int randomNumber;
    public int stage = 1;
    bool spawnPointBool=true;
    public float furyCooldown, furyCooldownMax;
    public Animator furyAnim;
    public Image healthbar;
    public Image[] stageImages;
    public Text stageText;
    public bool canRespawn = true;
    private void Start()
    {
        
        RandomGun();
        stage = PlayerPrefs.GetInt("Stage");
        playerGuns();
        if (stage < 4)
        {
            stage = 1;
        }
        else if(stage % 4 == 0)
        {
            stage -= 3;
        }
        else if (stage % 4 == 3)
        {
            stage -= 2;

        }
        else if (stage % 4 == 2)
        {
            stage -= 1;

        }
        stageText.text = stage.ToString();
        stageImages[0].gameObject.SetActive(false);
        stageImages[1].gameObject.SetActive(false);
        stageImages[2].gameObject.SetActive(false);
        stageImages[3].gameObject.SetActive(false);
        if (stage % 4 == 0 && stage != 0)
        {
            stageImages[3].gameObject.SetActive(true);
            stageImages[2].gameObject.SetActive(true);
            stageImages[1].gameObject.SetActive(true);
            stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 3 && stage != 0)
        {
            stageImages[2].gameObject.SetActive(true);
            stageImages[1].gameObject.SetActive(true);
            stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 2 && stage != 0)
        {
           stageImages[1].gameObject.SetActive(true);
            stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 1 && stage != 0)
        {
            stageImages[0].gameObject.SetActive(true);
        }
        
    }
    private void Update()
    {
        furyCooldown = furyCooldown - Time.deltaTime;
        if(furyCooldown <= 0)
        {
            furyAnim.SetTrigger("Fury");
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null)
                {
                    players[i].GetComponent<_2dxFX_Lightning>().enabled = true;
                    Invoke("FuryEnd", 10);

                }
            }
            furyCooldown = furyCooldownMax;
            
            Invoke("FuryCooldownReset", furyCooldownMax - 1);
        }
    }
    public void RandomGun ()
    {
        if(stage%4 == 0 && stage != 0)
        {
            //boss kodu
            stageImages[3].gameObject.SetActive(true);
            if (stage < 21)
            {//8.9.10.11 boss
                randomNumber = 7 + (stage - 5) / 4;
            }
            else
            {
              randomNumber = Random.Range(7, 11); //boss 
            }
            EnemyInstantiate();
        }

        else if (stage < 8)
        {  //normal enemy kodu
            randomNumber = Random.Range(0 , 3);
            EnemyInstantiate();
        }
              
        else
        {
           randomNumber = Random.Range(0 , 7);
            EnemyInstantiate();
        }
           
        if(stage%4 ==1 && stage != 0)
        {
            stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 1 && stage != 0 && stage > 4)
        {
            stageImages[1].gameObject.SetActive(false);
            stageImages[2].gameObject.SetActive(false);
            stageImages[3].gameObject.SetActive(false);
        }
        if (stage % 4 == 2 && stage != 0)
        {
            stageImages[1].gameObject.SetActive(true);
        }
        if (stage % 4 == 3 && stage != 0)
        {
            stageImages[2].gameObject.SetActive(true);
        }
    }
    void EnemyInstantiate()
    {
        if (canRespawn)
        {
            if (spawnPointBool)
            { 
               
                var tempGameobject = Instantiate(guns[randomNumber], enemySpawnPoint.position, Quaternion.identity);
                TinySauce.OnGameStarted(stage.ToString());
                tempGameobject.transform.SetParent(enemySpawnPoint.transform);
                healthbar.fillAmount = 1;
                spawnPointBool = !spawnPointBool;
                
            }
            else
            {
                var tempGameobject = Instantiate(guns[randomNumber], enemySpawnPointUp.position, Quaternion.identity);
                tempGameobject.transform.SetParent(enemySpawnPoint.transform);
                TinySauce.OnGameStarted(stage.ToString());
                healthbar.fillAmount = 1;
                spawnPointBool = !spawnPointBool;
            }
        }
        
    }
    public void playerGuns()
    {
        playerIndex[PlayerPrefs.GetInt("GunNumber")].SetActive(true);
    }
    public void NextEnemy()
    {
        stage++;
        PlayerPrefs.SetInt("Stage", stage);
        stageText.text = PlayerPrefs.GetInt("Stage").ToString();
        Invoke("RandomGun", 2f);

    }
   public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    private void FuryCooldownReset()
    {
        furyCooldown = furyCooldownMax;
    }

    void FuryEnd()
    {
 
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].GetComponent<_2dxFX_Lightning>().enabled = false;
            }
        }

    }
}
