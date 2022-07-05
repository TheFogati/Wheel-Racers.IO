using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_Script : MonoBehaviour
{
    public GameObject playerWheel;
    public GameObject[] rivalWheels;
    [Space]
    public GameObject holdText;

    private void Update()
    {
        playerWheel = GameObject.FindGameObjectWithTag("Player");
        rivalWheels = GameObject.FindGameObjectsWithTag("Wheel");
    }

    public void StartGame()
    {
        playerWheel.GetComponent<Tire_Script>().enabled = true;

        foreach (GameObject w in rivalWheels)
        {
            w.GetComponent<Tire_Script>().enabled = true;
        }
    }

    public void ShowText()
    {
        holdText.SetActive(true);
    }

    public void StartWheelsEngines()
    {
        playerWheel.GetComponent<EngineSound>().StartEngine();

        foreach (GameObject w in rivalWheels)
        {
            w.GetComponent<EngineSound>().StartEngine();
        }
    }

    public void KeepEnginesRunning()
    {
        playerWheel.GetComponent<EngineSound>().RunningEngine();

        foreach (GameObject w in rivalWheels)
        {
            w.GetComponent<EngineSound>().RunningEngine();
        }
    }
}
