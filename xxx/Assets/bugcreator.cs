using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugcreator : MonoBehaviour {

    public GameObject[] BugPref = new GameObject[3];

    private float TimeLeft = 5;

    public float AllTime = 5;

    private void Start()
    {
        int chance = Random.Range(1, 10);

        for (int i = 0; i < chance; i++)
        {
            Instantiate(BugPref[Random.Range(0, 3)]);
        }
    }

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            Instantiate(BugPref[Random.Range(0, 2)]);
            TimeLeft = Random.Range(0, AllTime -= (Time.time / 5000000.0f));
        }
    }
}
