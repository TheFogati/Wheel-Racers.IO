using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindWheel : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    GameObject playerWheel;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if(playerWheel == null)
        {
            playerWheel = GameObject.FindGameObjectWithTag("Wheel");
        }
        else
        {
            cam.Follow = playerWheel.transform;
            cam.LookAt = playerWheel.transform;
        }

    }
}
