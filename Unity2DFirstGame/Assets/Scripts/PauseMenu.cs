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
        // Prevents pause menu from popping up when game starts
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
        pauseMenuUI.SetActive(false);   // Closes menu
        Time.timeScale = 1f;    // Time continues again
        GameIsPaused = false;
    }

    void Pause()    {
        pauseMenuUI.SetActive(true);    // Brings up menu
        Time.timeScale = 0f;    // Freeze time
        GameIsPaused = true;
    }

    public void Menu()  {
        SceneManager.LoadScene(0);  // Loads the scene containing the main menu
    }

    public void QuitGame()  {
        Application.Quit();
    }

}
