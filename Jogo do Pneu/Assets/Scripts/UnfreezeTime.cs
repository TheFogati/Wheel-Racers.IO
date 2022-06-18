using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeTime : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
        GameManager.manager.gamePaused = false;
    }
}
