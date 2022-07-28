using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionKillRestart : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rigidBodyComponent;
    private string scene = "";

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D gameObj)    {
        if (gameObj.gameObject.name == "Player") {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
