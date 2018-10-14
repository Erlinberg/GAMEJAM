using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour {

    private float maxY = 5;

    private float maxX = 10;

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
        transform.position += transform.right * Time.deltaTime * movementSpeed;
        Debug.Log(transform.forward);
    }
}
