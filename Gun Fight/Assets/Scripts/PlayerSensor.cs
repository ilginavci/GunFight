﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {   if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().EnemyFire();
        }
     }
    
}
