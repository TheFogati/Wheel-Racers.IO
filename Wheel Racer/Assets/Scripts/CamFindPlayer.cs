using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFindPlayer : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    GameObject player;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    private void Update()
    {
        cam.Follow = player.transform;
        cam.LookAt = player.transform;
    }
}
