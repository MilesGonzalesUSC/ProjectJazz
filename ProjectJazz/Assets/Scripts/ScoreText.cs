using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreText : MonoBehaviour
{
    public float scaleTime;
    public float scaleMultiplier;

    private int _previousScore;
    private int _currentScore;

    private void ScaleScoreText()
    {
        transform.DOScale(transform.localScale * scaleMultiplier, scaleTime);
        transform.DOScale(transform.localScale, scaleTime).SetDelay(scaleTime);
    }

    private void Update()
    {
        _currentScore = GameManager.instance.currentScore;
        if (_currentScore != _previousScore)
        {
            ScaleScoreText();
            _previousScore = _currentScore;
        }
    }
}
