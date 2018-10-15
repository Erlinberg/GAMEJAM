using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {

    public int KilledBug = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(111);
        if (collision.transform.gameObject.name == "bug" & collision.transform.GetComponent<bug>().died == true)
        {
            KilledBug += 1;
            Destroy(collision.transform.gameObject);
        }
    }
}
