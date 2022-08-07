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
        rigidBodyComponent.velocity = new Vector2(10f,10f);

    }

    // Update is called once per frame
    void Update()
    {  
        
        Physics2D.IgnoreLayerCollision(7,7,true);   // Ignore Particle <-> Particle collisions

        lastVelocity = rigidBodyComponent.velocity; // We keep saving the last recorded velocity of the object every frame
       
    }

  

    void OnCollisionEnter2D(Collision2D collision)  {
        
        var speed = lastVelocity.magnitude;

        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal); // Get reflected direction

        rigidBodyComponent.velocity = direction * Mathf.Max(speed, 0f); // Always maintain the set speed when the particle is reflected so there is no speed lost
        
    }
}
