using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOrder : MonoBehaviour
{
    GameObject[] position;
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
            GameManager.manager.runs++;
        }

        other.tag = "Ended";
        other.GetComponent<Tire_Script>().enabled = false;
    }
}
