using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public bool directionUp;
    public float maxposY, minposY;
    


    void Update()
    {  if (directionUp)
        { 
            transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
            if(transform.position.y > maxposY)
            {
                directionUp = !directionUp;
            }
        }
    else
        {
            transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
            if (transform.position.y < minposY)
            {
                directionUp = !directionUp;
            }
        }
    }



}
