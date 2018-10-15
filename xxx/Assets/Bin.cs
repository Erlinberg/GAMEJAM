using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {

    public int KilledBug = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bug" & collision.GetComponent<bug>().died == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                KilledBug += 1;
                Destroy(collision.gameObject);
            }
        }
    }
}
