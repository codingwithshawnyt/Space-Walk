//Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

//Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections which allow for strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

//Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

//Declaring a public class named Gameplay that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class Gameplay : MonoBehaviour
{
    //The Start method is called before the first frame update. It's used for initialization.
    void Start()
    {
        //This is where we would put any code that needs to run at the start of the game. Currently, it's empty, be cause no such thing is needed.
    }
}

/* This script is a basic template for a Unity script. It doesn’t do anything yet (besides start the game) because the Start method is empty. 
You would add your own code inside Start to initialize any variables or set up any game objects when the game starts. 
The Gameplay class inherits from MonoBehaviour, which is the base class every script you create in Unity inherits from. 
It provides life-cycle functions such as Start(). */

