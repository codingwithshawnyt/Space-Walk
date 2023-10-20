// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections which allow for strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Importing the UnityEngine.UI namespace which contains all of the classes used for UI elements in Unity.
using UnityEngine.UI;

// Importing the TMPro (TextMeshPro) namespace which is a replacement for Unity's existing text components like Text Mesh and UI Text. TextMeshPro uses Signed Distance Field (SDF) as its primary text rendering pipeline making it possible to render text cleanly at any point size and resolution.
using TMPro;

// Declaring a public class named ItemCollector that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class ItemCollector : MonoBehaviour
{
    // Declaring a private integer variable named kiwis. This will be used to keep track of the number of kiwis collected.
    private int kiwis = 0;

    // Declaring a private TextMeshProUGUI variable named kiwisText. The [SerializeField] attribute allows private fields to be visible in the Unity editor.
    [SerializeField] private TextMeshProUGUI kiwisText;

    // OnTriggerEnter2D is called when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the object that collided with the trigger has a tag of "kiwi".
        if (collision.gameObject.CompareTag("kiwi"))
        { 
            // If it does, destroy the kiwi object, since it has been "collected".
            Destroy(collision.gameObject);

            // Increment the kiwis counter.
            kiwis++;

            // Update the kiwisText to display the current number of kiwis collected.
            kiwisText.text = "Kiwis: " +kiwis;

            // Save the current number of kiwis collected using PlayerPrefs. This allows the data to persist between game sessions.
            PlayerPrefs.SetInt("Kiwis", kiwis);
        }
    
    }
}

/* This script is used to collect items (in this case, “kiwis”). 
When an object tagged with “kiwi” enters this object’s trigger collider, it increments a counter, updates a UI text element to display the current count, and saves that count using PlayerPrefs so it persists between game sessions. 
The OnTriggerEnter2D method is called when another 2D collider enters this object’s trigger collider. 
The CompareTag method checks if the colliding object’s tag matches the specified string (“kiwi”). The Destroy method removes a game object, component or asset. 
The PlayerPrefs.SetInt method sets the value of the preference identified by key. This script should be attached to your player character in your Unity game. 
The “kiwi” objects should have 2D colliders on them set as triggers. When your player character enters a kiwi’s trigger collider, it will increment the counter, update the UI text, and save the count. 
Note that this script assumes you have set up a TextMeshProUGUI element in your scene for kiwisText. If not, kiwisText.text = "Kiwis: " +kiwis; will result in a NullReferenceException. 
Make sure you have set up a TextMeshProUGUI element in your scene and assigned it to kiwisText in this script’s inspector in Unity. */

