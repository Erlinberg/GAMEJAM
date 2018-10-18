using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour {

    private float maxY = 4;

    private float maxX = 8;

    private Vector3 offset;

    public float movementSpeed;

    private float Y;

    private float X;

    private IEnumerator coroutine;

    public GameObject particle;
    public Animator anim;

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

        coroutine = Rotate(Random.Range(0.5f,3.0f));

        StartCoroutine(coroutine);

        transform.position = new Vector2(X, Y);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {

            transform.position += transform.up * Time.deltaTime * movementSpeed;
    }

    void OnMouseDown()
    {
            offset = gameObject.transform.position -
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;

    }
}
