using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    private Color nextColor;
    Camera cm;

    void Start()
    {
        cm = GetComponent<Camera>();
        nextColor = cm.backgroundColor;
    }
    void FixedUpdate()
    {  //Background color
        cm.backgroundColor = Color.Lerp(cm.backgroundColor, nextColor, 0.01f);
    }
    public void ChangeScreen()
    {  //random color generator
        nextColor = new Color(
       Random.Range(0f, 1f),
       Random.Range(0f, 1f),
       Random.Range(0f, 1f)
    );

    }
}

