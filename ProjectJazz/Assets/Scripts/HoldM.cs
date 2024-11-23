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
            else
            {
                HandleMiss();
            }

            // Deactivate the note after processing
            gameObject.SetActive(false);
        }

        // If the note exits the activator while being held, it's a miss
        if (!canBePressed && isHolding)
        {
            HandleMiss();
            gameObject.SetActive(false);
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

            // If not holding, mark as missed
            if (!isHolding)
            {
                HandleMiss();
                gameObject.SetActive(false);
            }
        }
    }

    private void HandleMiss()
    {
        GameManager.instance.NoteMissed(); // Notify the GameManager of a miss
        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
    }
}
