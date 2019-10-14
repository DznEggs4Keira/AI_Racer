using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;

    public bool isGameOver;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");

        isGameOver = false;

        HideGameOver();
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1 && isGameOver == false)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0 && isGameOver == false)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }

        //shows finish gameobjects if player is dead and timescale = 0
        if (isGameOver == true)
        {
            HideGameOver();
        }
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //controls the pausing of the scene
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if (Time.timeScale == 0)
        {
            HidePaused();
            Time.timeScale = 1;
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
            Time.timeScale = 0;
            foreach (GameObject g in gameOverObjects)
            {
                g.SetActive(true);
            }
        }

        else if (isGameOver == false)
        {
            Time.timeScale = 1;
            foreach (GameObject g in gameOverObjects)
            {
                g.SetActive(false);
            }
        }
        
    }
}
