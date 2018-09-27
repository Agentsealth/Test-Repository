using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    public Text highScore;

    // Update is called once per frame
    void Start()
    {
        highScore.text = "High Score:" + PlayerPrefs.GetFloat("HighScore", 0).ToString();    
    }

    void Update () {

        float number = Mathf.Abs(player.position.x);
        scoreText.text = "Score: " + number.ToString("0");
        if(number > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", number);
            highScore.text ="High Score:" + number.ToString();
        }
        

    }
}
