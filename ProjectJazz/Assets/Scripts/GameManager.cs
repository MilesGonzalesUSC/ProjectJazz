using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public float currentScore;
    public int scorePerNote = 50;
    public int scorePerGoodNote = 75;
    public int scorePerPerfectNote = 100;

    public int scorePerHoldNote = 50;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;
    public float holdHits;
    public GameObject resultScreen;
    public Text finalScore;
    public Text normals, goods, perfects, misses, holds;

    public Flowchart flowchart;
    public string fungusBlock = "name";

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying)
            {   
                if (flowchart != null && flowchart.HasBlock(fungusBlock))
                {
                    flowchart.ExecuteBlock(fungusBlock);
                }
            }

        }
    }

    public void NoteHit()
    {

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
        missHits++;
    }

    public void HoldNoteCompleted()
    {
        // Optional: Add a bonus score for fully completing the hold note
        currentScore +=  scorePerHoldNote* currentMultiplier;
        NoteHit(); // Increment multiplier and update score display
        holdHits++;
    }

    public void AddScore(float points)
    {
        currentScore += points * currentMultiplier;
    }

    public void FreestyleHit()
    {
        if (currentScore <= 60000)
        {
            currentScore += scorePerPerfectNote * currentMultiplier;
            NoteHit();
            perfectHits++;
        }
    }

    public void ResultScreen()
    {
        if (!theMusic.isPlaying && !resultScreen.activeInHierarchy)
        {
            resultScreen.SetActive(true);

            normals.text = "" + normalHits;
            goods.text = goodHits.ToString();
            perfects.text = perfectHits.ToString();
            misses.text = "" + missHits;
            holds.text = "" + holdHits;
            finalScore.text = scoreText.text;
        }
    }
}
