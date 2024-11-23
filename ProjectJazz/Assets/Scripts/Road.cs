using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float generateInterval;
    public List<RectTransform> roadPoints = new();
    
    public IEnumerator GeneratePoints()
    {
        foreach (var roadPoint in roadPoints)
        {
            roadPoint.gameObject.SetActive(true);
            yield return new WaitForSeconds(generateInterval);
        }
    }
}
