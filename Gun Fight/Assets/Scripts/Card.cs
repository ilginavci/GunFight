using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    public Button buttonCenter, buttonLeft, buttonRight;
    private Animator centerAnim, leftAnim, rightAnim;
    public Sprite damageSprite, shotgunSprite, healthSprite,originalSprite;
    public Sprite[] gunSprites;
    private Button activeButton,dactiveButton1,dactiveButton2;
    private string[] functions;
    private GameObject[] players;
    private StageManager stageManager;

    private void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        players = stageManager.players;
    }

    public void Click()
    {
        centerAnim = GameObject.Find("Button_Center").GetComponent<Animator>();
        leftAnim = GameObject.Find("Button_Left").GetComponent<Animator>();
        rightAnim = GameObject.Find("Button_Right").GetComponent<Animator>();
        functions = new string[] {"Damage","Shotgun","Health","Gun0", "Gun1","Gun2","Gun3","Gun4", "Gun5"};


        if(gameObject.name == ("Button_Center"))
        {   
            activeButton = buttonCenter;
            dactiveButton1 = buttonLeft;
            dactiveButton2 = buttonRight;
        }else if (gameObject.name == ("Button_Left"))
        {
            activeButton = buttonLeft;
            dactiveButton1 = buttonCenter;
            dactiveButton2 = buttonRight;
        }else if (gameObject.name == ("Button_Right"))
        {
            activeButton = buttonRight;
            dactiveButton1 = buttonCenter;
            dactiveButton2 = buttonLeft;
        }

        activeButton.animator.SetTrigger("FlipCard");
        Invoke(functions[Random.Range(0,functions.Length)], 1f);
        Invoke("OriginalSprite", 2.8f);
        dactiveButton1.animator.SetTrigger("PushCards");
        dactiveButton2.animator.SetTrigger("PushCards");
    }

    private void OriginalSprite()
    {
        activeButton.image.sprite = originalSprite;
    }

    private void Damage()
    {
        activeButton.image.sprite = damageSprite;
        Debug.Log("damage verildi");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                if (players[i].GetComponent<Player>() != null)
                {
                    players[i].GetComponent<Player>().playerDamage = players[i].GetComponent<Player>().playerDamage + players[i].GetComponent<Player>().playerDamage / 15;

                }
                else if (players[i].GetComponent<ShotGun>() != null)
                {
                    players[i].GetComponent<ShotGun>().playerDamage = players[i].GetComponent<ShotGun>().playerDamage + players[i].GetComponent<ShotGun>().playerDamage / 15;

                }
            }
        }
    }
    private void Shotgun()
    {
        activeButton.image.sprite = shotgunSprite;
        Debug.Log("shotgun verildi");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[7].SetActive(true);
    }
    private void Health()
    {
        activeButton.image.sprite = healthSprite;
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            {
                if (players[i].GetComponent<Player>() != null)
                {
                    players[i].GetComponent<Player>().health = 100;
                    
                }
                else if (players[i].GetComponent<ShotGun>() != null)
                    {
                        players[i].GetComponent<ShotGun>().health = 100;

                    }
            }
            
        }
    }

    private void Gun0()
    {
        activeButton.image.sprite = gunSprites[0];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
                players[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        players[0].SetActive(true);
    }
    private void Gun1()
    {
        activeButton.image.sprite = gunSprites[1];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[1].SetActive(true);
    }
    private void Gun2()
    {
        activeButton.image.sprite = gunSprites[2];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[2].SetActive(true);
    }
    private void Gun3()
    {
        activeButton.image.sprite = gunSprites[3];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[3].SetActive(true);
    }
    private void Gun4()
    {
        activeButton.image.sprite = gunSprites[4];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[4].SetActive(true);
    }
    private void Gun5()
    {
        activeButton.image.sprite = gunSprites[5];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].SetActive(false);
            }
        }
        players[5].SetActive(true);
    }
}
