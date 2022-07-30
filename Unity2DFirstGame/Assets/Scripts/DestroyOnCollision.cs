using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnCollision : MonoBehaviour
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
        if (gameObj.gameObject.layer == 7) {
            RespawnPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj) {
        if (gameObj.gameObject.layer == 8)  {
            DestroyObject(gameObj.gameObject);
        }
    }

    void RespawnPlayer()    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    void DestroyObject(GameObject point)    {
        Destroy(point, 0.0f);
    }
}
