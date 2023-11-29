using System.Collections; //This line is importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections.Generic; //This line is importing the System.Collections.Generic namespace which provides generic collection classes. The term 'generic' means the same class can be used with many different types of data.
using UnityEngine; //This line is importing the UnityEngine namespace which contains all the classes you need to create scripts for your Unity game.
using UnityEngine.SceneManagement; //This line is importing the UnityEngine.SceneManagement namespace which provides classes to manage your game scenes.

//Define a public class named LevelTransition that inherits from MonoBehaviour, Unity's base class for everything attached to GameObjects
public class LevelTransition : MonoBehaviour
{
    //OnTriggerEnter2D is a method in the MonoBehaviour class. It is called when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the collision isn't null to prevent any null reference exceptions
        if (collision != null)
        {
            //If the object that triggered the event has a tag equal to "Player", then the following code will execute
            if (collision.tag.Equals("Player"))
            {
                //StartCoroutine starts a coroutine named LoadDelay. Coroutines allow you to pause execution until certain conditions are met
                StartCoroutine(LoadDelay());
            }
        }
    }

    //Define a method that is a coroutine which waits for 2 seconds before executing the next line of code
    private IEnumerator LoadDelay()
    {
        //WaitForSeconds is a yield instruction that pauses the execution of the coroutine for a given amount of seconds. In this case, it's 2 seconds.
        yield return new WaitForSeconds(2f);
        //After the wait, it calls the TransitionNextLevel method.
        TransitionNextLevel();
    }

    //This method uses SceneManager to load a new scene. It's how you transition between parts of your game (like going from a menu to gameplay, or from one level to another)
    private void TransitionNextLevel()
    {
        //LoadScene loads a new scene by its name or index in Build Settings. It's used here to load a scene named "Levels Screen".
        SceneManager.LoadScene("Levels Screen");
    }
}

/* This script is attached to the level completion flag that serves as a trigger for level transitions. 
When your player character enters this object’s area, it triggers a delay of 2 seconds before loading the next level. */
