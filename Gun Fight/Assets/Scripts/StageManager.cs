using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] guns;
    public Transform enemySpawnPoint;
    int randomNumber;
    int stage = 1;
    private void Start()
    {
        RandomGun();
        EnemyInstantiate();
    }
    void RandomGun ()
    {
        if (stage == 1)
        {
            randomNumber = Random.Range(0, 3);
        }
    }
    void EnemyInstantiate()
    {
        Instantiate( guns[randomNumber], enemySpawnPoint.position, Quaternion.identity );
    }
    
    public void NextEnemy()
    {
        Invoke("RandomGun", 3);
        Invoke("EnemyInstantiate",3);
        

    }
    public void RandomCard()
    {

    }
}
