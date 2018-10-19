using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class superslojnayamekanika : MonoBehaviour {

    public int timePrc = 100;

    public float projectReady = 0;

    public float speedOfDev = 1;

    public float stress = 0;

    public float spawn = 1;

    public float V_max = 5;

    public float B_middle = 25;

    public float AllTime = 120;

    public int Bugs = 5;

    private float TimeLeft;

    public RuntimeAnimatorController win;

    public RuntimeAnimatorController dead;

    public GameObject panel;

    public GameObject panel1;

    public Text tptxt;

    public Text prtxt;

    public Text sodtxt;

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
        spawn = stress;
    }

    void Speed()
    {
        speedOfDev = (((B_middle + (B_middle / V_max)) / (Bugs + (B_middle / V_max))) * (1 / stress)) / 2;
    }

    private void Start()
    {
        TimeLeft = AllTime / timePrc;
    }
    void Update ()
    {
        if (!(projectReady >= 100))
        {
            if (!(timePrc <= 0))
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
                    tptxt.text = timePrc.ToString() + "%";
                    prtxt.text = Mathf.Round(projectReady).ToString() + "%";
                }

                Bugs = GameObject.FindGameObjectsWithTag("Warning").Length + GameObject.FindGameObjectsWithTag("Error").Length * 2 + GameObject.FindGameObjectsWithTag("Fatal Error").Length * 5;
            }

            else
            {
                GetComponent<Animator>().runtimeAnimatorController = dead;
                panel.SetActive(true);
            }
        }

        else
        {
            if (!(timePrc <= 0))
            {
                GetComponent<Animator>().runtimeAnimatorController = win;
                panel1.SetActive(true);
            }

            else
            {
                GetComponent<Animator>().runtimeAnimatorController = dead;
                panel.SetActive(true);
            }
        }
    }

}
