using UnityEngine;
using UnityEngine.UI;

public class ScoreProgressBar : MonoBehaviour
{
    public float nodeValue1;
    public float nodeValue2;
    public Color nodeColor1;
    public Color nodeColor2;
    public Color nodeColor3;
    
    [SerializeField] private Slider progressBar;

    private GameManager _gameManager;
    private Image _fill;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _fill = progressBar.fillRect.GetComponent<Image>();
    }

    private void Update()
    {
        progressBar.value = _gameManager.currentScore;
        if (progressBar.value < nodeValue1)
        {
            _fill.color = nodeColor1;
        }
        else if(progressBar.value >= nodeValue1 && progressBar.value < nodeValue2)
        {
            _fill.color = nodeColor2;
        }
        else if (progressBar.value >= nodeValue2)
        {
            _fill.color = nodeColor3;
        }
    }
}
