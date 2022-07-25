using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rigidBodyComponent;
    private Vector3 lastVelocity;
   // private float maxSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent.AddForce(new Vector2(500f, 500f));
        InvokeRepeating("IncreaseVelocity", 10f, 10f);

    }

    // Update is called once per frame
    void Update()
    {  

        lastVelocity = rigidBodyComponent.velocity; // We keep saving the last recorded velocity of the object every frame

        if (Mathf.Abs(lastVelocity.y) <= 5f || Mathf.Abs(lastVelocity.x) <= 5f) {
            lastVelocity.y = 10f;
            lastVelocity.x = 10f;
        }

        Debug.Log(rigidBodyComponent.velocity);
       
    }

    void IncreaseVelocity() {
        lastVelocity.y += 1f;
        lastVelocity.x += 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.layer == 7)    {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  {
        

        // Ignore collision forces on player
        if (collision.gameObject.layer == 6) {
            return;
        }

        var speed = lastVelocity.magnitude;

        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal); // Get reflected direction
        

        rigidBodyComponent.velocity = direction * Mathf.Max(speed, 0f); // Always maintain the set speed when the particle is reflected so there is no speed lost
        
    }
}
