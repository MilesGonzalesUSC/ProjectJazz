using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EventController : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startPlaying()
    {
        if (gamePanel != null)
        {
            gamePanel.SetActive(true);
        }

        if (UI != null)
        {
            UI.SetActive(true);
        }
    }
}
