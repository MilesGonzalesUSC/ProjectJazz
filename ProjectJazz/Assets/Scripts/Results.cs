using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI perfectText;
    public TextMeshProUGUI goodText;
    public TextMeshProUGUI normalText;
    public TextMeshProUGUI holdText;
    public TextMeshProUGUI missText;
    
    [Header("Total Score")]
    public TextMeshProUGUI totalScoreText;
    public GameObject fullComboText;
    public float scoreAddTime;
    private float _scoreToAdd;

    [Header("Score Level")] 
    public TextMeshProUGUI levelText;
    public float SLevel;
    public float ALevel;
    public float BLevel;
    public float CLevel;

    private void OnEnable()
    {
        var accuracy = 1 - (GameManager.instance.missHits / GameManager.instance.totalNotes);
        accuracyText.text = "ACCURACY: " + accuracy.ToString("F2") + "%";
        perfectText.text = "PERFECT: " + GameManager.instance.perfectHits;
        goodText.text = "GOOD: " + GameManager.instance.goodHits;
        normalText.text = "NORMAL: " + GameManager.instance.normalHits;
        holdText.text = "HOLD: " + GameManager.instance.holdHits;
        missText.text = "MISS: " + GameManager.instance.missHits;
        ShowTotalScore();
        ShowLevel();
    }

    private void ShowTotalScore()
    {
        _scoreToAdd = 0;
        DOTween.To(() => _scoreToAdd, value => _scoreToAdd = value, GameManager.instance.currentScore, scoreAddTime)
            .SetEase(Ease.OutQuint).OnComplete(ShowLevel);
        if (GameManager.instance.missHits == 0)
        {
            fullComboText.SetActive(true);
        }
    }

    private void Update()
    {
        totalScoreText.text = _scoreToAdd.ToString("F0");
    }

    private void ShowLevel()
    {
        if (GameManager.instance.currentScore >= SLevel)
        {
            levelText.text = "S";
        }
        else if(GameManager.instance.currentScore >= ALevel)
        {
            levelText.text = "A";
        }
        else if(GameManager.instance.currentScore >= BLevel)
        {
            levelText.text = "B";
        }
        else if(GameManager.instance.currentScore >= CLevel)
        {
            levelText.text = "C";
        }
        else
        {
            levelText.text = "D";
        }
        levelText.gameObject.SetActive(true);
    }
}
