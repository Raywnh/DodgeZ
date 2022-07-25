using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKill : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        
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
        rigidBodyComponent.position = new Vector2(0,2);
    }
}
