using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreestyleBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject freestyleEffect;
    public bool canBePressed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            {
                if (canBePressed)
                {
                    Instantiate(freestyleEffect, transform.position, freestyleEffect.transform.rotation);
                     GameManager.instance.FreestyleHit();
                }
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            gameObject.SetActive(false);   
        }
    }
}
