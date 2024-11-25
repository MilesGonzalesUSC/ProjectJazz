using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreestyleBlock : MonoBehaviour
{
    public GameObject freestyleEffect;
    public bool canBePressed;

    // Audio clips for each arrow
    public AudioClip upArrowClip;
    public AudioClip downArrowClip;
    public AudioClip leftArrowClip;
    public AudioClip rightArrowClip;

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on this GameObject.");
        }
    }

    void Update()
    {
        if (canBePressed)
        {
            // Check for specific arrow keys
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayAudioClip(upArrowClip);
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayAudioClip(downArrowClip);
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PlayAudioClip(leftArrowClip);
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PlayAudioClip(rightArrowClip);
                TriggerEffect();
            }
        }
    }

    private void TriggerEffect()
    {
        // Instantiate effect and trigger GameManager action
        Instantiate(freestyleEffect, transform.position, freestyleEffect.transform.rotation);
        GameManager.instance.FreestyleHit();
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
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
}
