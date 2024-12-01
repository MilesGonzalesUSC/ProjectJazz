using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldM : MonoBehaviour
{
    public bool canBePressed; // Whether the note is in the activator zone
    public bool isHolding;    // Whether the player is holding the key

    public KeyCode keyToHold; // Key to press and hold

    public GameObject hitEffect, missEffect;

    private float holdTime = 0f; // Time the player has been holding the key
    public float requiredHoldTime = 1f; // The required time to complete the hold
    private float scoreTimer = 0f; // Timer to track score increment

    public int scorePerHold = 10; // Points to reward for every 0.1 seconds of holding the note

    void Update()
    {
        // Start holding if the key is pressed and the note can be pressed
        if (Input.GetKeyDown(keyToHold) && canBePressed)
        {
            isHolding = true;
            holdTime = 0f; // Reset hold time when the key is pressed
            scoreTimer = 0f; // Reset the score increment timer
            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
        }

        // If the key is being held, count the time the player holds it
        if (isHolding)
        {
            holdTime += Time.deltaTime; // Increment hold time

            // Increment score every 0.1 seconds
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= 0.1f)
            {
                scoreTimer = 0f; // Reset timer
                AddScore(scorePerHold); // Add score for holding the note
            }

            // If the player holds the key for enough time and is still in the activator zone
            if (holdTime >= requiredHoldTime && canBePressed)
            {
                CompleteHoldNote(); // Complete the hold note with a bonus
                isHolding = false; // Stop holding after completion
            }
        }

        // Stop holding if the key is released
        if (Input.GetKeyUp(keyToHold) && isHolding)
        {
            isHolding = false;

            // If the player didn't hold the key long enough, handle it as a miss
            if (canBePressed && holdTime < requiredHoldTime)
            {
                HandleMiss(); // Notify the GameManager of a miss
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = true; // The note can be pressed once inside the activator zone
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false; // The note can no longer be pressed once outside the activator zone

            // If the note is not being held, consider it a miss
            if (isHolding && holdTime < requiredHoldTime)
            {
                HandleMiss(); // Handle miss when the player exits without holding it correctly
            }

            gameObject.SetActive(false); // Disable the note after exiting the activator zone
        }
    }

    private void AddScore(int points)
    {
        GameManager.instance.AddScore(points); // Increment score by a certain amount (defined as scorePerHold)
    }

    private void CompleteHoldNote()
    {
        GameManager.instance.HoldNoteCompleted(); // Notify the GameManager
    }

    private void HandleMiss()
    {
        GameManager.instance.NoteMissed(); // Notify the GameManager of a miss
        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
    }
}
