using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectObject : MonoBehaviour
{
    
    public float lifetime = 1f;

    private Vector3 _originalScale;
    
    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        transform.DOScale(transform.localScale * 1.1f, 0.15f);
        transform.DOScale(_originalScale, 0.15f).SetDelay(0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
