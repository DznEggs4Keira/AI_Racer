﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;

    public bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");

        HideGameOver();
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            HideGameOver();
        }

        else
        {
            //uses the p button to pause and unpause the game
            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseControl();
            }
        }
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //controls the pausing of the scene
    void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        //if called on any other scene, takes to main menu
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }

        //else quits application
        else
        {
            Application.Quit();
        }
    }

    public void HideGameOver()
    {
        if(isGameOver == true)
        {
            foreach (GameObject g in gameOverObjects)
            {
                g.SetActive(true);
            }
        }

        else
        {
            foreach (GameObject g in gameOverObjects)
            {
                g.SetActive(false);
            }
        }
        
    }
}
