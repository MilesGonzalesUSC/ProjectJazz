using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playagain : MonoBehaviour
{
    // Public references to UI panels and game UI
    public GameObject uiPanel;   // Reference to the UI panel to enable
    public GameObject gameUI;    // Reference to the Game UI to enable
    public AudioSource audioSource;  // Reference to the AudioSource to unpause

    // Function to enable UI panels, game UI, and unpause the audio
    public void PlayAgain()
    {
        // Enable the UI panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);  // Show the UI panel again
        }

        // Enable the game UI
        if (gameUI != null)
        {
            gameUI.SetActive(true);  // Show the Game UI again
        }

        // Unpause the audio
        if (audioSource != null)
        {
            audioSource.UnPause();  // Resume the audio
        }
    }
}
