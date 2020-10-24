using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Color[] nextColor;
    Camera cm;
    public Color zero,one,two,tree,four,five,six,seven,eight,nine;
    int randomColor=0;

    

    void Start()
    {
      
        cm = GetComponent<Camera>();
        nextColor =  new Color[] { zero, one, two, tree, four, five, six, seven, eight, nine };
    }
    void FixedUpdate()
    {  //Background color
        cm.backgroundColor = Color.Lerp(cm.backgroundColor, nextColor[randomColor], 0.01f);
    }
    public void ChangeScreen()
    {  // Random Bg color
       int tempRandom = Random.Range(0,9);  
        if(randomColor != tempRandom)
        {
            randomColor = tempRandom;
        }
        else
        {
            ChangeScreen();
        }
    }
}

