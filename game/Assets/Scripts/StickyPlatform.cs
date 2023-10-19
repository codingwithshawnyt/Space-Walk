using System.Collections; // This line is importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.

using System.Collections.Generic; // This line is importing the System.Collections.Generic namespace which provides generic collection classes. The term 'generic' means the same class can be used with many different types of data.

using UnityEngine; // This line is importing the UnityEngine namespace which contains all the classes you need to create scripts for your Unity game.

public class StickyPlatform : MonoBehaviour // This line is declaring a public class named 'StickyPlatform' that inherits from the 'MonoBehaviour' class. MonoBehaviour is the base class from which every Unity script derives.

{
    private void OnTriggerEnter2D(Collider2D collision) // This method is called when another object enters a trigger collider attached to this object (a 2D physics trigger).

    {
        if (collision.gameObject.name == "Player") // Check if the collided object is named "Player".

        {
            collision.gameObject.transform.SetParent(transform); // If it is, set this object (the sticky platform) to be the parent of the player object. This means the player will move together with the platform.
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // This method is called when another object leaves a trigger collider attached to this object (a 2D physics trigger).

    {
        if (collision.gameObject.name == "Player") // Check if the collided object is named "Player".

        {
            collision.gameObject.transform.SetParent(null); // If it is, remove the parent of the player object. This means the player will stop moving together with the platform.
        }
    }
}

//This script appears to be for a platform in a game that can carry a player character along with it when they step onto it.

