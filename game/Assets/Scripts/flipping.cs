using System.Collections; //Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.

using System.Collections.Generic; //Importing the System.Collections.Generic namespace which provides generic collection classes. The term 'generic' means the same class can be used with many different types of data.

using UnityEngine; //Importing the UnityEngine namespace which contains all the classes you need to create scripts for your Unity game.

public class flipping : MonoBehaviour //Declaring a public class named 'flipping' that inherits from the 'MonoBehaviour' class. MonoBehaviour is the base class from which every Unity script derives.

{
    public SpriteRenderer spr; //Declaring a public variable of type SpriteRenderer named 'spr'. This variable will be used to manipulate the sprite of this object.

    public WayPointFollower ways; //Declaring a public variable of type WayPointFollower named 'ways'. This variable will be used to access the WayPointFollower component attached to this object.
    

    private void OnTriggerEnter2D(Collider2D collision) //Called when another object enters a trigger collider attached to this object (a 2D physics trigger).

    {
        if (collision.gameObject.name == "Player")  //Check if the collided object is named "Player".

        {
            Destroy(this.gameObject);  //If it is, destroy this game object.
        }
    }

    void Update() //This method is called once per frame in Unity.

    {

        if (ways.currentWaypointIndex == 1) //Check if the current waypoint index of 'ways' is 1.

        {
            spr.flipX = true; //If it is, flip the sprite on the X axis.
        }
        else 
        {
            spr.flipX = false; //If it's not, don't flip the sprite on the X axis.
        }
    }
}

//This script flips its sprite on the X axis when it reaches a certain waypoint and destroys itself when it collides with an object named “Player” (the user's character).
//As of November 29, 2023, it has yet to be implemented into the game.

