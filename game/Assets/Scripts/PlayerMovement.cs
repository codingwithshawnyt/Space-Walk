// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections which allow for strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Declaring a public class named PlayerMovement that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class PlayerMovement : MonoBehaviour
{
    // Declaring private variables for the Rigidbody2D, BoxCollider2D, SpriteRenderer, Animator, and Transform components.
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private Transform rotation;

    // Declaring serialized fields that can be set in the Unity editor.
    [SerializeField] private LayerMask jumpableGround; // The layers that the player can jump off of.
    [SerializeField] private float moveSpeed = 7f; // The speed at which the player moves.
    [SerializeField] private float jumpForce = 14f; // The force of the player's jump.

    // Declaring a private variable for the player's horizontal direction.
    private float dirX = 0;

    // Declaring an enum for the player's movement state. This will be used to control animations.
    private enum MovementState { idle, running, jumping, falling }

    // The Start method is called before the first frame update. It's used for initialization.
    private void Start()
    {
        // Getting the Rigidbody2D component attached to this object and assigning it to rb.
        rb = GetComponent<Rigidbody2D>();

        // Getting the BoxCollider2D component attached to this object and assigning it to coll.
        coll = GetComponent<BoxCollider2D>();

        // Getting the SpriteRenderer component attached to this object and assigning it to sprite.
        sprite = GetComponent<SpriteRenderer>();

        // Getting the Animator component attached to this object and assigning it to anim.
        anim = GetComponent<Animator>();

        // Freezing rotation on rb so it doesn't rotate when colliding with other objects.
        rb.freezeRotation = true;
    }

    // Update is called once per frame. It's used for regular updates such as moving non-physics objects.
    private void Update()
    {
        // Getting input from the player for horizontal movement and assigning it to dirX.
        dirX = Input.GetAxisRaw("Horizontal");

        // Setting rb's velocity to move the player horizontally at moveSpeed. Keeps current vertical velocity.
        if (rb.bodyType != RigidbodyType2D.Static) 
        {
            rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        }
        // Checking if the player has pressed space or up arrow and if they are grounded (literally, on the ground). If they have, make them jump.
        if (Input.GetKeyDown("space") | Input.GetKeyDown("up") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }

        // Calling UpdateAnimationState to update the player's animation based on their movement state.
        UpdateAnimationState();
    }

    // Method to update the player's animation based on their movement state.
    private void UpdateAnimationState()
    {
        MovementState state;

        // Checking if dirX is greater than 0 (player is moving right).
        if (dirX > 0f)
        {
            state = MovementState.running; // Set state to running.
            sprite.flipX = false; // Don't flip sprite (keep it facing right).
        }
        else if (dirX < 0f) // Checking if dirX is less than 0 (player is moving left).
        {
            state = MovementState.running; // Set state to running.
            sprite.flipX = true; // Flip sprite (make it face left).
        }
        else
        {
            state = MovementState.idle; // If dirX is not greater than or less than 0 (player is not moving), set state to idle.
        }

        if (rb.velocity.y > .1f) // Checking if rb's vertical velocity is greater than .1 (player is moving up).
        {
            state = MovementState.jumping; // Set state to jumping.
        }
        else if (rb.velocity.y < -.1f) // Checking if rb's vertical velocity is less than -.1 (player is moving down).
        {
            state = MovementState.falling; // Set state to falling.
        }

        anim.SetInteger("state", (int)state); // Setting "state" in anim to the current movement state. This will control which animation plays.

    }

    // Method to check if the player is grounded by casting a BoxCast downwards just below the player's collider and checking if it hits anything on the jumpableGround layer.
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

/* This script is used where you want your player character to be able to move left and right, jump, and have different animations based on their movement state. 
The Start method gets the Rigidbody2D, BoxCollider2D, SpriteRenderer, and Animator components attached to this object (which should be your player character) and assigns them to rb, coll, sprite, and anim. 
It also freezes rotation on rb so it doesn’t rotate when colliding with other objects. The Update method gets input from the player for horizontal movement and sets rb.velocity to move the player horizontally at moveSpeed. 
It also checks if the player has pressed space or up arrow and if they are grounded, and if they have, it makes them jump. It then calls UpdateAnimationState to update the player’s animation based on their movement state. 
The UpdateAnimationState method checks the player’s horizontal and vertical movement and sets their movement state accordingly. It then sets “state” in anim to the current movement state, which controls which animation plays. 
The IsGrounded method checks if the player is grounded by casting a BoxCast downwards just below the player’s collider and checking if it hits anything on the jumpableGround layer. */

