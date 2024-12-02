using UnityEngine;
using UnityEngine.UI; // Include this if you want to work with UI components

public class Exit : MonoBehaviour
{
    // Method to be called on button click
    public void ExitGame()
    {
        // Log a message to the console (optional)
        Debug.Log("Exiting the game...");

        // If running in the editor, stop playing the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a standalone build, quit the application
        Application.Quit();
#endif
    }
}


