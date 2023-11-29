//Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

//Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections which allow for strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

//Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

//Declaring a public class named Finish that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class Finish : MonoBehaviour
{
    //Declaring a private AudioSource variable named finishSound. This will be used to play a sound when the player finishes.
    private AudioSource finishSound;

    //The Start method is called before the first frame update. It's used for initialization.
    void Start()
    {
        //Getting the AudioSource component attached to this object and assigning it to the finishSound variable (this will come in handy later).
        finishSound = GetComponent<AudioSource>();
    }

    //OnTriggerEnter2D is called when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the object that collided with the trigger has a name of "Player" (because if it's not the player, then the user hasn't finished).
        if (collision.gameObject.name == "Player")
            //If it does, play the finish sound.
            finishSound.Play();
            //And declare that in the log
            Debug.Log("Level Completed");
    }
}

/* This script is used where we want a sound to play when the player reaches a certain point (a finish line). 
The OnTriggerEnter2D method is called when another 2D collider enters this object’s trigger collider. If that object is named “Player”, it plays the finishSound. 
The GetComponent<AudioSource>() call in the Start method gets the AudioSource component attached to this object (which should be set up to play your desired sound) and assigns it to finishSound. 
This script should be attached to your finish line object in your Unity game. The “Player” object should have a 2D collider on it set as a trigger. 
When the player enters the finish line’s trigger collider, it will play the sound. Note that this script assumes you have set up an AudioSource on your finish line object with your desired sound. 
If not, GetComponent<AudioSource>() will return null and trying to call Play() on it will result in a NullReferenceException. 
Make sure you have set up an AudioSource on your finish line object in Unity (if you're taking this straight from GitHub, you should be fine). */
