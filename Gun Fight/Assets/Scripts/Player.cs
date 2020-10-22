using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float startPosX, startPosY;
    public float objectPosX,maxposY,minposY;
    private bool beingHeld = false;
    






    void Update()
    {
        if(beingHeld == true)
        {
            
                Vector3 mousepos;
                mousepos = Input.mousePosition;
                mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            this.gameObject.transform.localPosition = new Vector3(objectPosX, mousepos.y, 0);
            
            
        }

        if (gameObject.transform.position.y >= maxposY)
        {
            gameObject.transform.position = new Vector2(objectPosX, maxposY - 0.1f);
        }
        else if (gameObject.transform.position.y <= minposY)
        {
            gameObject.transform.position = new Vector2(objectPosX, minposY + 0.1f);
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
