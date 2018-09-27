using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour {

    public PlayerCharacters Player;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
	public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Player.GetComponent<Animator>().SetBool("Dead", true);
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
