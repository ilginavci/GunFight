using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] players;
    public Transform enemySpawnPoint, enemySpawnPointUp;
    int randomNumber;
    public int stage = 1;
    bool spawnPointBool=true;
    public GameObject canvasGame, canvasDeath;

    private void Start()
    {
        RandomGun();
       
    }
    void RandomGun ()
    {
        print(stage);
        if(stage%4 == 0 && stage != 0)
        {
            //boss kodu
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
    }
    void EnemyInstantiate()
    {
        if (spawnPointBool)
        {
            var tempGameobject= Instantiate(guns[randomNumber], enemySpawnPoint.position, Quaternion.identity);
            tempGameobject.transform.SetParent(enemySpawnPoint.transform);
            spawnPointBool = !spawnPointBool;
        }
        else
        {
            var tempGameobject= Instantiate(guns[randomNumber], enemySpawnPointUp.position , Quaternion.identity);
            tempGameobject.transform.SetParent(enemySpawnPoint.transform);
            spawnPointBool = !spawnPointBool;
        }
    }
    
    public void NextEnemy()
    {
        stage++;
        if (stage > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", stage);
        }
        Invoke("RandomGun", 2f);

    }
   public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
