using System.Collections.Generic;
using UnityEngine;

public class ScoreProgressBar : MonoBehaviour
{
    public int maxScore;
    
    [SerializeField] private List<GameObject> fills = new();
    
    private void Update()
    {
        var maxIndex = GameManager.instance.currentScore * 10 / maxScore;
        for (int i = 0; i < Mathf.Floor(maxIndex); i++)
        {
            fills[i].SetActive(true);
        }
    }
}
