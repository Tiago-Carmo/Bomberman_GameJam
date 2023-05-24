using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    private static int count = 0;
    private const string CountKey = "Count";
    private static int mapIndex = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey(CountKey))
        {
            count = PlayerPrefs.GetInt(CountKey);
        }
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount <= 1 && count >= 2 && mapIndex == 0)
        {
            mapIndex++;
            Invoke(nameof(NextMap), 0f);
        }
        else if (aliveCount <= 1 && count >= 2 && mapIndex == 1)
        {
            mapIndex++;
            Invoke(nameof(EndGame), 0f);
        }
        else
        {
            count++;
            Debug.Log(count);
            Invoke(nameof(NewRound), 1f);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}

