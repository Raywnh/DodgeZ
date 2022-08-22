using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScreen : MonoBehaviour
{   

    [SerializeField] private GameObject RespawnScreenUI;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        RespawnScreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead && Input.GetMouseButtonDown(0))   {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            dead = false;
        }
    }
    
    public void SetPlayerDead()    {
        dead = true;
        RespawnScreenUI.SetActive(true);
    }
}
