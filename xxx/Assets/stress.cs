using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stress : MonoBehaviour {


    public float stressprc = 100.0f;

    public float everybug = 0;

    public Text stresstext;
	

    void FindNum()
    {
        everybug = GameObject.FindGameObjectsWithTag("Warning").Length / 5.0f + GameObject.FindGameObjectsWithTag("Error").Length / 3.0f + GameObject.FindGameObjectsWithTag("Fatal Error").Length;
    }

	void Update ()
    {
        FindNum();

        stressprc = 100.0f - everybug;

        stresstext.text =  stressprc.ToString() + "%";
	}
}
