using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {

    public int KilledBug = 0;

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.transform.gameObject.name == "bug" & collision.transform.GetComponent<bug>().died == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                KilledBug += 1;
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
