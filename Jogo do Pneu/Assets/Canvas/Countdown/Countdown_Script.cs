using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_Script : MonoBehaviour
{
    public GameObject playerWheel;
    public GameObject[] rivalWheels;

    private void Update()
    {
        playerWheel = GameObject.FindGameObjectWithTag("Player");
        rivalWheels = GameObject.FindGameObjectsWithTag("Wheel");
    }

    public void StartGame()
    {
        playerWheel.GetComponent<Tire_Script>().enabled = true;

        foreach(GameObject w in rivalWheels)
        {
            w.GetComponent<Tire_Script>().enabled = true;
        }
    }
}
