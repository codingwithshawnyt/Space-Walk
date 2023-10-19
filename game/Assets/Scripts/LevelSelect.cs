// Importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections;

// Importing the System.Collections.Generic namespace which contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.
using System.Collections.Generic;

// Importing the UnityEngine namespace which contains all of the classes, structures and enumerations that Unity uses.
using UnityEngine;

// Importing the UnityEngine.UI namespace which contains all of the classes used for UI elements in Unity.
using UnityEngine.UI;

// Importing the UnityEngine.SceneManagement namespace which allows you to manage your game's scenes, load and unload scenes, and travel between scenes in your game.
using UnityEngine.SceneManagement;

// Declaring a public class named LevelSelect that inherits from MonoBehaviour. MonoBehaviour is the base class from which every Unity script derives.
public class LevelSelect : MonoBehaviour
{
    // Declaring public variables that can be set in the Unity editor.
    public int noOfLevels; // The number of levels in the game.
    public GameObject levelButton; // The button used to select a level.
    public RectTransform ParentPanel; // The parent panel for the level buttons.
    public int levelReached; // The highest level reached by the player.
    public int kiwis; // The number of kiwis collected by the player.

    // Declaring a private variable to keep track of the current index.
    private int index = 0;

    // Declaring a public variable for the number of kiwis needed to unlock the next level.
    public int neededKiwis = 5;

    // Declaring a list to store all of the level buttons.
    List<GameObject> buttons = new List<GameObject>();

    // Awake is called when the script instance is being loaded. It's used for initialization before Start is called.
    private void Awake()
    {
        // Calling the LevelButtons method to create all of the level buttons.
        LevelButtons();
    }

    // Method to create all of the level buttons.
    void LevelButtons()
    {
        // Checking if there is a saved value for "level" in PlayerPrefs. PlayerPrefs is used to store simple data between game sessions.
        if (PlayerPrefs.HasKey("level"))
        {
            // If there is, get that value and assign it to levelReached.
            levelReached = PlayerPrefs.GetInt("level");
        }
        else
        {
            // If there isn't, set "level" in PlayerPrefs to 1 and assign that value to levelReached.
            PlayerPrefs.SetInt("level", 1);
            levelReached = PlayerPrefs.GetInt("level");
        }

        // Looping through all of the levels.
        for (int i = 0; i < noOfLevels; i++)
        {
            // Creating a new integer x and setting it equal to i + 1. This will be used as the level number for this button.
            int x = new int();
            x = i + 1;

            // Instantiating a new level button and setting its parent to ParentPanel. Instantiate is used to create a new instance of a game object in your scene at runtime.
            GameObject lvlbutton = Instantiate(levelButton);
            lvlbutton.transform.SetParent(ParentPanel, false);

            // Getting the Text component from lvlbutton's children and setting its text to x. This will display the level number on the button.
            Text buttontext = lvlbutton.GetComponentInChildren<Text>();
            buttontext.text = (i + 1).ToString();

            // Adding an onClick listener to lvlbutton's Button component. When clicked, it will call LevelSelected with x as an argument.
            lvlbutton.gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                LevelSelected(x);
            });

            /* Commented out code:
               If i + 1 is greater than levelReached (the highest level reached by the player), make this button not interactable (it can't be clicked).
               This would be used if you want players to have to complete each level in order before they can play the next one.

            if (i + 1 > levelReached)
            {
                lvlbutton.GetComponent<Button>().interactable = false;
            }
            */

            // Adding lvlbutton to buttons list. This will be used later if you want to unlock levels as players collect more kiwis.
            buttons.Add(lvlbutton);
        }
    }

    /* Commented out code:
       Method that would be called when a player collects enough kiwis to unlock a new level.

    public void CheckForNextLevel()
    {
        kiwis = PlayerPrefs.GetInt("Kiwis");

        Debug.Log(kiwis);

        if (kiwis >= neededKiwis)
        {
            Debug.Log("Unlock Level");
            UnlockNextLevel();
        }
    }

    void UnlockNextLevel()
    {
        Debug.Log("unlocked");
        kiwis = 0;
        neededKiwis++;
        index++;
        buttons[index].GetComponent<Button>().interactable = true;
        Debug.Log(buttons[index].name);
    }
    */

    // Method that is called when a level button is clicked. The index of the button is passed as an argument.
    void LevelSelected(int index)
    {
        // Saving the selected level in PlayerPrefs. This allows the data to persist between game sessions.
        PlayerPrefs.SetInt("levelSelected", index);

        // Logging the selected level to the console.
        Debug.Log("Level Selected: " + index.ToString());

        // Starting a coroutine to load the selected level after a delay. StartCoroutine is used to start a coroutine.
        StartCoroutine(LoadDelay(index));
    }

    // Coroutine to load the selected level after a delay. Coroutines allow you to pause execution and return control to Unity but then to continue where you left off on the following frame.
    private IEnumerator LoadDelay(int index)
    {
        // Waiting for 2 seconds before continuing. WaitForSeconds is used to pause a coroutine for a specified amount of time.
        yield return new WaitForSeconds(2f);

        // Calling LoadLevels with index as an argument after the delay.
        LoadLevels(index);
    }

    // Method to load the selected level. The index of the level is passed as an argument.
    void LoadLevels(int index)
    {
        // Loading the scene with the name "Level " + index. SceneManager.LoadScene is used to load a scene.
        SceneManager.LoadScene("Level " + index);
    }
}

//This script is typically used in a game where you have multiple levels that can be selected from a menu. It creates a button for each level, and when a button is clicked, it loads that level. The Awake method is called when the script instance is being loaded, before any Start methods are called. It’s used here to call LevelButtons, which creates all of the level buttons. The LevelButtons method first checks if there’s a saved value for “level” in PlayerPrefs, which is used to store simple data between game sessions. If there isn’t, it sets “level” in PlayerPrefs to 1. Then it loops through all of the levels, creates a button for each one, and adds an onClick listener to each button that calls LevelSelected with the level number as an argument. The LevelSelected method saves the selected level in PlayerPrefs, logs it to the console, and starts a coroutine that loads the selected level after a delay. The LoadDelay coroutine waits for 2 seconds, then calls LoadLevels. The LoadLevels method loads the scene with the name "Level " + index. Note that this script assumes you have set up your scenes in Unity with names like “Level 1”, “Level 2”, etc., and that you have added those scenes to your build settings’ Scenes In Build list. If not, SceneManager.LoadScene("Level " + index); will not work.

