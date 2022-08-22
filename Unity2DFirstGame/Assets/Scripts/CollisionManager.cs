using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rigidBodyComponent;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {   

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D gameObj)    {

        // Kill our player if we touch the particles
        if (gameObj.gameObject.layer == 7) {
            KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj) {

        // Destroy the points object if we touch it
        if (gameObj.gameObject.layer == 8)  {
            DestroyPoints(gameObj.gameObject);
            ChangeScore();
        }

        if (gameObj.gameObject.layer == 11) {
            DestroyShields(gameObj.gameObject);
            GiveShield();
        }
    }

    public void ShieldOn() {
        Physics2D.IgnoreLayerCollision(6,7,true);
    }
    
    public void ShieldOff()    {
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    void KillPlayer()    {
        Destroy(player);
        FindObjectOfType<RespawnScreen>().SetPlayerDead();
    }

    void DestroyPoints(GameObject point)    {
        Destroy(point, 0.0f);
        FindObjectOfType<SpawnPoints>().decreaseNumberOfPoints();
    }

    void DestroyShields(GameObject shield)  {
        Destroy(shield,0.0f);
        FindObjectOfType<SpawnShields>().decreaseNumberOfShields();
    }

    void ChangeScore()  {
        FindObjectOfType<ScoreKeep>().IncreaseScoreByPoints(); // Finds our ScoreKeep class and increases points
    }

    void GiveShield()   {
        FindObjectOfType<PlayerShield>().TurnOnShield();
    }
    
}
