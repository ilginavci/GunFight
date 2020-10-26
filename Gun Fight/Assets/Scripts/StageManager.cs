using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public Transform enemySpawnPoint, enemySpawnPointUp;
    int randomNumber;
    int stage = 0;
    bool spawnPointBool=true;
    private void Start()
    {
        RandomGun();
       
    }
    void RandomGun ()
    {   
        if(stage%3 == 0 )
        {
            //boss kodu
            if (stage < 21)
            {
                randomNumber = Random.Range(0 + stage / 4, 3 + stage / 4); //boss
            }
            else
            {
                randomNumber = Random.Range(0, 7); //boss 
            }
        }
        else if (stage < 21)
        {  //normal enemy kodu
            randomNumber = Random.Range(0 + stage / 4, 3 + stage / 4);
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
        Invoke("RandomGun", 2f);

    }
    public void RandomCard()
    {

    }
}
