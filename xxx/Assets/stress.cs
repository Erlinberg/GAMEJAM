using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stress : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite[] s = new Sprite[3];

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = s[0];
    }

    private void Update()
    {
        if (transform.GetComponentInParent<superslojnayamekanika>().stress < 2.0f)
        {
            sr.sprite = s[0];
        }

        else if (transform.GetComponentInParent<superslojnayamekanika>().stress > 2.0f & transform.GetComponentInParent<superslojnayamekanika>().stress < 4.0f)
        {
            sr.sprite = s[1];
        }

        else if (transform.GetComponentInParent<superslojnayamekanika>().stress > 4.0f)
        {
            sr.sprite = s[2];
        }
    }
}
