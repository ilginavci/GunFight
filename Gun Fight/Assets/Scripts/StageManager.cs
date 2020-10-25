using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public Transform enemySpawnPoint;
    int randomNumber;
    int stage = 0;
    private void Start()
    {
        RandomGun();
       
    }
    void RandomGun ()
    {
        if (stage < 17)
        {
            randomNumber = Random.Range(0 + stage / 4, 3 + stage / 4);
        }
        else
        {

        }
           EnemyInstantiate();

    }
    void EnemyInstantiate()
    {
        Instantiate( guns[randomNumber], enemySpawnPoint.position, Quaternion.identity );
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
