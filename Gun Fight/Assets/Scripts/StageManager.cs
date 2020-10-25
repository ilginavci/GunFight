using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    GameObject[] guns;
    public Transform enemySpawnPoint;
    public GameObject gun1, gun2, gun3, gun4, gun5, gun6, gun7, gun8, gun9;
    // Start is called before the first frame update
    void Start()
    {
        guns = new GameObject[] { gun1, gun2, gun3, gun4, gun5, gun6, gun7, gun8, gun9 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomGun ()
    {
        int randomNumber = Random.Range(0, 2);
    }
}
