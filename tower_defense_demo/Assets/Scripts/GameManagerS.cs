using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerS : MonoBehaviour
{
    public static bool gameEnded = false;
    public static bool gameWon = false;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    private void Start()
    {
        gameEnded = false;
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (PlayerStats.killedObjects == 8)
        {
            GameWon();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    void GameWon()
    {
        gameWon = true;
        gameWonUI.SetActive(true);
    }
}
