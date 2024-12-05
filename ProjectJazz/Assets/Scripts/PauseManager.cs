using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource[] audioSources;

    void Start()
    {
        // Cache all active audio sources in the scene
        audioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        // Check if the player presses the "P" key (or any key you choose)
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;

            // Pause all audio
            foreach (AudioSource audioSource in audioSources)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
            }

            // Optional: Show pause menu UI
            Debug.Log("Game Paused");
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f;

            // Resume all audio
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.UnPause();
            }

            // Optional: Hide pause menu UI
            Debug.Log("Game Resumed");
        }
    }
}
