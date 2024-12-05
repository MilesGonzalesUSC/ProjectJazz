using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public GameObject gameObjectToFly;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                ButtonFlyToBar();
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();

                float distanceFromHitbox = Mathf.Abs(transform.position.x + 6.5f);

                if (distanceFromHitbox > 0.35f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (distanceFromHitbox > 0.15f)
                {
                    Debug.Log("Good!");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect!!!");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    public void ButtonFlyToBar()
    {
        if (gameObjectToFly == null) return;
        var thisButton = Instantiate(gameObjectToFly);
        Vector3[] path = { transform.position, new Vector3(-8f, 1f, 0), new Vector3(-5.5f, 4.5f, 0) };
        thisButton.transform.DOPath(path, 0.5f, PathType.CatmullRom).OnComplete(() => Destroy(thisButton));
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

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
