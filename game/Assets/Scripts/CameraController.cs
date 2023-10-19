// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Declaring a public class named CameraController that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class CameraController : MonoBehaviour
{
    // Declaring a private Transform variable named player. The [SerializeField] attribute allows private fields to be visible in the Unity editor.
    [SerializeField] private Transform player;

    // The Update method is called every frame. It's used for regular updates such as moving non-physics objects.
    private void Update()
    {
        // Setting the position of the camera (this object) to follow the player's x and y coordinates, while keeping its own z coordinate.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}

//This script is typically used in a 2D game where you want the camera to follow the player’s movements. The Update method ensures that the camera’s position is updated every frame to match the player’s position. The [SerializeField] attribute is used to allow the player variable to be set directly from the Unity editor, providing a convenient way to link this script to the player object. The Transform class represents an object’s position, rotation and scale in 3D space. In this case, it’s used to track and follow the player’s position. The Vector3 class represents 3D vectors and points, used here to create a new position for the camera based on the player’s position. The MonoBehaviour class is a base class every script you create in Unity inherits from. It provides life-cycle functions such as Update(). This script should be attached to the camera object in your Unity game.
