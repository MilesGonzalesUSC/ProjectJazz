using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressImage;
    public KeyCode keyToPress;

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
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
