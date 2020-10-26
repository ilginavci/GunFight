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
    private Button activeButton,dactiveButton1,dactiveButton2;
    private string[] functions;

    public void Click()
    {
        centerAnim = GameObject.Find("Button_Center").GetComponent<Animator>();
        leftAnim = GameObject.Find("Button_Left").GetComponent<Animator>();
        rightAnim = GameObject.Find("Button_Right").GetComponent<Animator>();
        functions = new string[] {"Damage","Shotgun","Health"};


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
    }
    private void Shotgun()
    {
        activeButton.image.sprite = shotgunSprite;
        Debug.Log("shotgun verildi");

    }
    private void Health()
    {
        activeButton.image.sprite = healthSprite;
        Debug.Log("health verildi");
    }
}
