using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugcreator : MonoBehaviour {

    public GameObject[] BugPref = new GameObject[3];

    private float TimeLeft = 1;

    public float AllTime = 1;

    private void Start()
    {
        int chance = Random.Range(3, 10);

        for (int i = 0; i < chance; i++)
        {
            int what = Random.Range(0, 100);

            if (what <= 60)
            {
                Instantiate(BugPref[0]);
            }

            else if (what > 60 & what < 90)
            {
                Instantiate(BugPref[1]);
            }
        }
    }

    private void Update()
    {
        int what = Random.Range(0, 100);
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            what = Random.Range(0, 100);

            if (what <= 60)
            {
                Instantiate(BugPref[0]);
            }

            else if (what > 60 & what < 90)
            {
                Instantiate(BugPref[1]);
            }

            else if (what >= 90)
            {
                Instantiate(BugPref[2]);
            }
            TimeLeft = AllTime / GetComponent<superslojnayamekanika>().spawn;
        }
    }
}
