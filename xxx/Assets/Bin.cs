using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {

    public int KilledBug = 0;

    public string type;

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (Input.GetMouseButtonUp(0))
            {
                if (collision.tag == type)
                {
                        KilledBug += 1;
                        Destroy(collision.gameObject);
                }
            }
    }
}
