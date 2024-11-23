using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldM : MonoBehaviour
{
    public bool canBePressed; // Whether the note is in the activator zone
    public bool isHolding;    // Whether the player is holding the key

    public KeyCode keyToHold; // Key to press and hold

    public GameObject hitEffect, missEffect;

    void Update()
    {
        // Start holding if the key is pressed and the note can be pressed
        if (Input.GetKeyDown(keyToHold) && canBePressed)
        {
            isHolding = true;
            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
        }

        // Stop holding if the key is released
        if (Input.GetKeyUp(keyToHold) && isHolding)
        {
            isHolding = false;

            // If still in activator zone, reward for completion
            if (canBePressed)
            {
                GameManager.instance.HoldNoteCompleted(); // Notify the GameManager
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            gameObject.SetActive(false);
 
        }
    }

    private void HandleMiss()
    {
        GameManager.instance.NoteMissed(); // Notify the GameManager of a miss
        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
    }
}
