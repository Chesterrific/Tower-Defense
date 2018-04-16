using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;
    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update () {
		if(PlayerStats.Lives <= 0)
        {
            if (GameIsOver)
                return;

            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true); //how to enable and disable objects typically.
    }

}
