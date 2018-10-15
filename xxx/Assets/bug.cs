using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour {

    private float maxY = 4;

    private float maxX = 8;

    private Vector3 offset;

    public int health = 3;

    public float movementSpeed;

    private float Y;

    private float X;

    public bool died = false;

    private IEnumerator coroutine;

    IEnumerator Rotate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int z = Random.Range(-360, 360);
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }

    // Use this for initialization
    void Start ()
    {
        Y = Random.Range(-maxY, maxY);
        X = Random.Range(-maxX, maxX);

        coroutine = Rotate(2.0f);

        StartCoroutine(coroutine);

        transform.position = new Vector2(X, Y);
    }

    // Update is called once per frame
    void Update ()
    {
        if (health <= 0)
        {
            died = true;
            StopCoroutine(coroutine);
        }

        else
        {
            if (transform.position.x >= maxX || transform.position.x <= -maxX || transform.position.y >= maxY || transform.position.y <= -maxY)
            {
                transform.rotation *= Quaternion.Euler(0, 0, 180);
            }
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
    }

    void OnMouseDown()
    {
        if (died)
        {
            offset = gameObject.transform.position -
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    void OnMouseDrag()
    {
        if (died)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    private void OnMouseUpAsButton()
    {
        health -= 1;
    }
}
