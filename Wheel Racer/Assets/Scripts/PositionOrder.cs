using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionOrder : MonoBehaviour
{
    GameObject[] position;
    public GameObject[] confetti;
    public static int playerPosition;

    void Start()
    {

    }

    void Update()
    {
        position = GameObject.FindGameObjectsWithTag("Ended");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerPosition = position.Length + 1;
            Points.endIt = true;
            Points.position = playerPosition;
            GameManager.manager.runs++;

            switch(playerPosition)
            {
                case 1:
                    confetti[0].SetActive(true);
                    break;
                case 2:
                    confetti[1].SetActive(true);
                    break;
                case 3:
                    confetti[2].SetActive(true);
                    break;
            }
        }

        other.tag = "Ended";
        other.GetComponent<EngineSound>().StopEngine();
        other.GetComponent<Tire_Script>().enabled = false;
        other.GetComponent<Tire_Script>().StopParticles();
    }
}
