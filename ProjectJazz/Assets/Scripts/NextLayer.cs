using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class NextLayer : MonoBehaviour
{
    public string nextLayer;  // Name of the scene to load
    public float interactionDistance = 5f; // Maximum distance for interaction
    public Color loadToColor;
    public ParticleSystem particleEffect; // Reference to the particle system

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransferToNextScene()
    {
        Initiate.Fade(nextLayer, loadToColor, 0.5f);  // Load the next scene
    }

    public void Effect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play(); // Play the particle effect
        }
        else
        {
            Debug.LogWarning("Particle effect is not assigned.");
        }
    }
}
