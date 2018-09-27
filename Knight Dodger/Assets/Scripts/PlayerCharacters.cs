using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters : Entity {

    public JoyButton joy;
    public SwipeController swipe;
    public Score score;
	// Use this for initialization
	void Start () {
#if UNITY_ANDROID

#else
    joy.gameObject.SetActive(false);
    score.gameObject.SetActive(true);
#endif
        
        base.Start();
		
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
#if UNITY_ANDROID
        _rawVals = new Vector4(0,
                                0,
                                joy.Vertical(),
                               joy.Horizontal()
            );
#else
        _rawVals = new Vector4(Input.GetAxis("Strafe"),
                                0,
                                Input.GetAxis("Vertical"),
                               Input.GetAxis("Horizontal")
            );
#endif
        if (Input.GetButtonDown("Fire1"))
        {
            SetActIdx(1);
        }

        if (Input.GetButton("Fire2"))
        {
            SetActIdx(2);
        }

        if(transform.position.y < -1f)
        {
            FindObjectOfType<GameManger>().EndGame();
        }

        ApplyMovement();
        ApplyRotation();
	}
}
