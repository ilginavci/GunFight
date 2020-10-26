using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] players;
    public Transform enemySpawnPoint, enemySpawnPointUp;
    int randomNumber;
    public int stage = 1;
    bool spawnPointBool=true;
    public float furyCooldown, furyCooldownMax;
    public Animator furyAnim;
    public Image healthbar;
    public Image[] stageImages;
    public Text stageText;
    private void Start()
    {
        RandomGun();
        stage = PlayerPrefs.GetInt("Stage");
        stageText.text = stage.ToString();
        stageImages[0].gameObject.SetActive(false); stageImages[1].gameObject.SetActive(false); stageImages[2].gameObject.SetActive(false); stageImages[3].gameObject.SetActive(false);
        if (stage % 4 == 0 && stage != 0)
        {
            stageImages[3].gameObject.SetActive(true); stageImages[2].gameObject.SetActive(true); stageImages[1].gameObject.SetActive(true); stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 1 && stage != 0)
        {
            stageImages[2].gameObject.SetActive(true); stageImages[1].gameObject.SetActive(true); stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 2 && stage != 0)
        {
           stageImages[1].gameObject.SetActive(true); stageImages[0].gameObject.SetActive(true);
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
            furyCooldown = furyCooldownMax;
            Invoke("FuryCooldownReset", furyCooldownMax - 1);
        }
    }
    void RandomGun ()
    {
        print(stage);
        if(stage%4 == 0 && stage != 0)
        {
            //boss kodu
            stageImages[3].gameObject.SetActive(true);
            if (stage < 21)
            {
                randomNumber = Random.Range(0 + (stage -1)/ 4, 3 + stage / 4); //boss
            }
            else
            {
                randomNumber = Random.Range(0, 7); //boss 
            }
        }
        else if (stage < 21)
        {  //normal enemy kodu
            randomNumber = Random.Range(0 + (stage -1) / 4, 3 + stage / 4);
        }
        else
        {
           randomNumber = Random.Range(0 , 7);
        }
           EnemyInstantiate();
        if(stage%4 ==1 && stage != 0)
        {
            stageImages[0].gameObject.SetActive(true);
        }
        if (stage % 4 == 1 && stage != 0 && stage > 4)
        {
            stageImages[1].gameObject.SetActive(false); stageImages[2].gameObject.SetActive(false); stageImages[3].gameObject.SetActive(false);
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
        if (spawnPointBool)
        {
            var tempGameobject= Instantiate(guns[randomNumber], enemySpawnPoint.position, Quaternion.identity);
            tempGameobject.transform.SetParent(enemySpawnPoint.transform);
            healthbar.fillAmount = 1;
            spawnPointBool = !spawnPointBool;
        }
        else
        {
            var tempGameobject= Instantiate(guns[randomNumber], enemySpawnPointUp.position , Quaternion.identity);
            tempGameobject.transform.SetParent(enemySpawnPoint.transform);
            healthbar.fillAmount = 1;
            spawnPointBool = !spawnPointBool;
        }
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
}
