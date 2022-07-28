using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rigidBodyComponent;
    private Vector3 lastVelocity;

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

    }

    void IncreaseVelocity() {
        lastVelocity.y += 5f;
        lastVelocity.x += 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        // Ignore particle <-> particle collisions so that no velocity is lost during collisions
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)    {
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
