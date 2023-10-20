using System.Collections; // This line is importing the System.Collections namespace which provides interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
using System.Collections.Generic; // This line is importing the System.Collections.Generic namespace which provides generic collection classes. The term 'generic' means the same class can be used with many different types of data.
using UnityEngine; // This line is importing the UnityEngine namespace which contains all the classes you need to create scripts for your Unity game.
using UnityEngine.SceneManagement; // This line is importing the UnityEngine.SceneManagement namespace which provides classes to manage your game scenes.


public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (collision.tag.Equals("Player"))
            {
                StartCoroutine(LoadDelay());
            }
        }
    }


    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(2f);
        TransitionNextLevel();
    }

    private void TransitionNextLevel()
    {
        SceneManager.LoadScene("Levels Screen");
    }
}
