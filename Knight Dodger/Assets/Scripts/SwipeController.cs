using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {
    Vector2 delta;
    string dir;

    // Update is called once per frame
    void Update () {

        if(Input.touchCount == 0)
        {
            return;
        }

        delta = Input.GetTouch(Input.touches.Length - 1).position - Input.GetTouch(0).position;
        if(delta.sqrMagnitude != 0 && delta.sqrMagnitude > 30)
        {
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                //swipe horizontal
                if (delta.x > 0)
                {
                    dir = "right";
                    //swipe right
                }
                else
                {
                    dir = "left";
                    //swipe left
                }
            }
            else
            {
                //swipe vertical
                if (delta.y > 0)
                {
                    dir = "up";
                    //swipe up
                }
                else
                {
                    dir = "down";
                    //swipe down
                }
            }
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 200), dir);
    }

}
