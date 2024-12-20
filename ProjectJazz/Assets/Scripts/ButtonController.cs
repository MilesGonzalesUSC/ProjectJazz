using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressImage;
    public KeyCode keyToPress;
    private SpriteRenderer _spriteRenderer;
    private Color _originColor;
    private Vector3 _originScale;
  

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originColor = _spriteRenderer.color;
        _originScale = transform.localScale;
    }
    
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressImage;
            transform.DOScale(transform.localScale * 0.9f, 0.1f);
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
            transform.DOScale(_originScale, 0.1f);
        }
    }

 

}
