using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private int extraJumps = 3;
    private float horizontalInput;
    private float speed = 13f;
    private float jumpingPower = 9f;
    private bool isJumping = false;
    private bool downPress = false;
    

    [SerializeField] private Rigidbody2D rigidBodyComponent;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && extraJumps > 0)  {
            isJumping = true;
        }
    
        if (Input.GetKeyDown("s") && !IsGrounded())  {
            downPress = true;
        }

        if (IsGrounded()) {
            extraJumps = 3; // Reset amount of extra jumps
        }
        
    }

    void FixedUpdate()  {
        rigidBodyComponent.velocity = new Vector2(horizontalInput*speed, rigidBodyComponent.velocity.y);

        if (isJumping)  {
            rigidBodyComponent.velocity = new Vector2(rigidBodyComponent.velocity.x, jumpingPower);

            isJumping = false;
            extraJumps--;
        }

        // Allows players to move downwards even when midair
        if (downPress)  {
            rigidBodyComponent.velocity = new Vector2(rigidBodyComponent.velocity.x,-jumpingPower);
            downPress = false;
        }

    }

    private bool IsGrounded()   {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);  // Returns if the ground layer touches the player
    }
}
