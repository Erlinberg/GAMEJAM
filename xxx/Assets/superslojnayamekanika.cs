using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superslojnayamekanika : MonoBehaviour {

    public int timePrc = 100;

    public float projectReady = 0;

    public float speedOfDev = 1;

    public float stress = 0;

    public float spawn = 1;

    public float V_max = 10;

    public float B_middle = 20;

    public float AllTime = 120;

    public int Bugs = 5;

    private float TimeLeft;

    void Stresss()
    {
        stress = (100 - projectReady) / timePrc;
        if (stress < 1)
        {
            stress = 1;
        }
    }

    void Spawn()
    {
        spawn = 2 * stress - 1;
    }

    void Speed()
    {
        speedOfDev = (((B_middle + (B_middle / V_max)) / (Bugs + (B_middle / V_max))) * (1 / stress));
    }

    private void Start()
    {
        TimeLeft = AllTime / timePrc;
    }
    void Update ()
    {
        TimeLeft -= Time.deltaTime;

        if (TimeLeft < 0)
        {
            timePrc -= 1;
            Stresss();
            Spawn();
            Speed();
            projectReady += speedOfDev;
            TimeLeft = AllTime;
        }

        Bugs = GameObject.FindGameObjectsWithTag("Warning").Length + GameObject.FindGameObjectsWithTag("Error").Length*2 + GameObject.FindGameObjectsWithTag("Fatal Error").Length*5;
    }
}
