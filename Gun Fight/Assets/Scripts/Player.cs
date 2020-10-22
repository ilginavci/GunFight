using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float startPosX, startPosY;
    public float objectPosX,maxposY,minposY;
    private bool beingHeld = false;
    public float cooldown,cooldownMax;
    public GameObject bullet;
    public Transform spawnPoint;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if(beingHeld == true)
        {
            
                Vector3 mousepos;
                mousepos = Input.mousePosition;
                mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            if (mousepos.y < maxposY && mousepos.y > minposY)
            {
                this.gameObject.transform.localPosition = new Vector3(objectPosX, mousepos.y, 0);
            }
            if (cooldown <= 0)
            {
                cooldown = cooldownMax;
                Instantiate(bullet,spawnPoint.transform.position,Quaternion.identity);
                animator.SetTrigger("Shoot");
                
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

                startPosY = mousepos.y - this.transform.localPosition.y;
            
            beingHeld = true;
        }

        
    }

    private void OnMouseUp()
    {
        beingHeld = false;
    }


}
