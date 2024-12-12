using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FreestyleBlock : MonoBehaviour
{
    public GameObject freestyleEffect;
    public bool canBePressed;

    // Audio clips for each arrow
    public AudioClip upArrowClip;
    public AudioClip downArrowClip;
    public AudioClip leftArrowClip;
    public AudioClip rightArrowClip;
    public GameObject gameObjectToFly;
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
                ButtonFlyToBar();
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayAudioClip(downArrowClip);
                ButtonFlyToBar();
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PlayAudioClip(leftArrowClip);
                ButtonFlyToBar();
                TriggerEffect();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PlayAudioClip(rightArrowClip);
                ButtonFlyToBar();
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

    public void ButtonFlyToBar()
    {
        if (gameObjectToFly == null) return;
        var thisButton = Instantiate(gameObjectToFly);
        Vector3[] path = { transform.position, new Vector3(-8f, 1f, 0), new Vector3(-5.5f, 4.5f, 0) };
        thisButton.transform.DOPath(path, 0.5f, PathType.CatmullRom).OnComplete(() => Destroy(thisButton));
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
