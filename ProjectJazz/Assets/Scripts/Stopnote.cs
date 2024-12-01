using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; // Make sure Fungus is referenced

public class Stopnote : MonoBehaviour
{
    public Flowchart flowchart; // Reference to the Flowchart
    public string blockName; // Name of the Fungus block to execute
    public GameObject notepad;
    public GameObject UI;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" && notepad.activeSelf)
        {
            // Disable the GameObject
            notepad.SetActive(false);

            if (UI != null)
            {
                UI.SetActive(false);
            }

            if (audioSource != null)
            {
                audioSource.Pause(); // Pause the audio
            }

            // Trigger the Fungus block named "string"
            if (flowchart != null)
            {
                flowchart.ExecuteBlock(blockName);
            }
        }
    }
}
