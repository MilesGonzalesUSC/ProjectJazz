using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public int currentLevel;
    public RectTransform playerMark;
    public Image blackFade;
    public List<string> sceneLevels = new();
    public List<Road> roads = new();
    
    private Road _currentRoad;

    private void Awake()
    {
        _currentRoad = roads[currentLevel];
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        blackFade.DOFade(0, 2).OnComplete(GenerateRoad);
    }

    private void GenerateRoad()
    {
        StartCoroutine(_currentRoad.GeneratePoints());
        Invoke(nameof(MovePlayerMark), _currentRoad.roadPoints.Count * _currentRoad.generateInterval);
    }

    private void MovePlayerMark()
    {
        var path = new Vector3[_currentRoad.roadPoints.Count];
        var offset = new Vector3(0, 50f, 0);
        for (int i = 0; i < _currentRoad.roadPoints.Count; i++)
        {
            path[i] = _currentRoad.roadPoints[i].position + offset;
        }
        playerMark.DOPath(path, 1.5f)
            .OnComplete(()=> playerMark.DOLocalMoveY(playerMark.localPosition.y + 5f, 0.2f)
                .SetLoops(4, LoopType.Yoyo).OnComplete(ChangeScene));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateRoad();
        }
    }

    private void ChangeScene()
    {
        blackFade.DOFade(1, 2)
            .OnComplete(()=>SceneManager.LoadScene(sceneLevels[currentLevel + 1]));
    }
}