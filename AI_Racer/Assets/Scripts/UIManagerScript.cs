using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;

    bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");

        hideGameOver();
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
            //uses the p button to pause and unpause the game
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseControl();
            }
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //controls the pausing of the scene
    void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
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

    void hideGameOver()
    {
        foreach(GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }
}
