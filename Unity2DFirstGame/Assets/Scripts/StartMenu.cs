using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()    {
        SceneManager.LoadScene(1);  // Loads the scene containing the main game
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenGuide()    {
        SceneManager.LoadScene(2);
    }
}
