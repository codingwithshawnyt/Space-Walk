// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections which allow for strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Importing the UnityEngine.SceneManagement namespace which allows you to manage your game's scenes, load and unload scenes, and travel between scenes in your game.
using UnityEngine.SceneManagement;

// Declaring a public class named PlayerLife that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class PlayerLife : MonoBehaviour
{
    // Declaring private variables for the Animator and Rigidbody2D components.
    private Animator anim;
    private Rigidbody2D rb;

    // The Start method is called before the first frame update. It's used for initialization.
    void Start()
    {
        // Getting the Rigidbody2D component attached to this object and assigning it to rb.
        rb = GetComponent<Rigidbody2D>();

        // Getting the Animator component attached to this object and assigning it to anim.
        anim = GetComponent<Animator>(); 
    }

    // OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider (2D physics only).
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checking if the object that collided with this one has a tag of "trap".
        if (collision.gameObject.CompareTag("trap"))
        { 
            // If it does, call the Death method (below).
            Death();
        }
       
    }

    // Method to handle what happens when the player dies.
    private void Death()
    {
        // Setting the bodyType of rb to Static. This makes it unaffected by forces or collisions.
        rb.bodyType = RigidbodyType2D.Static;

        // Setting the "death" trigger on anim. This will play the "death" animation.
        anim.SetTrigger("death");
    }

    // Method to restart the current level.
    public void RestartLevel()
    {
        // Loading the scene with the same name as the currently active scene. This effectively restarts the level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

/* This script is typically used in a game where you want something to happen when your player character dies (like playing a death animation and restarting the level). 
The Start method gets the Rigidbody2D and Animator components attached to this object (which should be your player character) and assigns them to rb and anim. 
The OnCollisionEnter2D method is called when this object’s collider begins touching another collider. If that other collider has a tag of “trap”, it calls Death. 
The Death method sets rb.bodyType to RigidbodyType2D.Static, which makes it unaffected by forces or collisions, and sets the “death” trigger on anim, which should play a death animation. 
The RestartLevel method loads the scene with the same name as the currently active scene, effectively restarting the level. 
Note that this script assumes you have set up an animation for your player character’s death in Unity with a trigger named “death”. 
If not, anim.SetTrigger("death"); will not work. Also note that this script assumes you have added a tag of “trap” to any objects in your scene that should kill your player character on contact. 
If not, collision.gameObject.CompareTag("trap") will always be false. Make sure you have set up these things in Unity for this script to work as expected. */

