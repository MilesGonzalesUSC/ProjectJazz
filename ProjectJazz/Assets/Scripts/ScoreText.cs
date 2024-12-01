using UnityEngine;
using DG.Tweening;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public float scaleTime;
    public float scaleMultiplier;
    
    [SerializeField] private TextMeshProUGUI scoreToAddText;

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
            ShowScoreToAdd(_currentScore - _previousScore);
            _previousScore = _currentScore;
        }
    }

    private void ShowScoreToAdd(int score)
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
