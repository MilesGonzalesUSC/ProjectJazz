using System;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public float scaleTime;
    public float scaleMultiplier;
    
    [SerializeField] private TextMeshProUGUI scoreToAddText;

    private float _previousScore;
    private float _currentScore;
    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void ScaleScoreText()
    {
        transform.DOScale(_originalScale * scaleMultiplier, scaleTime);
        transform.DOScale(_originalScale, scaleTime).SetDelay(scaleTime);
    }

    private void Update()
    {
        _currentScore = GameManager.instance.currentScore;
        if (_currentScore != _previousScore)
        {
            ScaleScoreText();
            ShowScoreToAdd(_currentScore - _previousScore);
            _previousScore = _currentScore;
        }
    }

    private void ShowScoreToAdd(float score)
    {
        scoreToAddText.gameObject.SetActive(false);
        scoreToAddText.transform.localScale = Vector3.one;
        scoreToAddText.transform.DOKill();
        
        scoreToAddText.text = score.ToString();
        scoreToAddText.gameObject.SetActive(true);
        scoreToAddText.transform.DOScale(Vector3.one * 1.1f, 0.1f);
        scoreToAddText.transform.DOScale(Vector3.one, 0.1f).SetDelay(0.5f).OnComplete(() => scoreToAddText.gameObject.SetActive(false));
    }
}
