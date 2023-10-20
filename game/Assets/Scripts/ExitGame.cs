// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Declaring a public class named ExitGame that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class ExitGame : MonoBehaviour
{
    // Declaring a method named QuitGame. This method will be used to quit the application.
    void QuitGame()
    {
        // Calling the Quit method on the Application class. This will quit the application when run in a standalone build. In the editor, it effectively does not do anything.
        Application.Quit();
    }
}
/* This script is used to create an exit button. When the QuitGame method is called (usually through a button click event), it will cause the application to quit. 
Note that Application.Quit() does not work in the Unity editor or in web builds, it only works in standalone builds of your game. In the Unity editor, it will simply stop playmode. 
This script should be attached to the object in the Unity game that you want to use to trigger the quit action (in our case, an exit button). */
