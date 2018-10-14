using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour {

    private float maxY = 4;

    private float maxX = 8;

    public float movementSpeed;

    private float Y;

    private float X;

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
        if (transform.position.x >= maxX || transform.position.x <= -maxX || transform.position.y >= maxY || transform.position.y <= -maxY)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 180);
            Debug.Log(123);
        }
        transform.position += transform.right * Time.deltaTime * movementSpeed;
    }
}
