using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour  
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameIsPaused)  {
            Resume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   {
            if (GameIsPaused)   {
                Resume();
            }
            else    {
                Pause();
            }
        }
    }

    public void Resume()   {
        pauseMenuUI.SetActive(false); // Brings down menu
        Time.timeScale = 1f; // Resume game
        GameIsPaused = false;
    }

    void Pause()    {
        pauseMenuUI.SetActive(true); // Brings up menu
        Time.timeScale = 0f; // Freeze game
        GameIsPaused = true;
    }

    public void Menu()  {

    }

    public void QuitGame()  {
        Application.Quit();
    }

}