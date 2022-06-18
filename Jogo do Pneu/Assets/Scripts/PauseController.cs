using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        GameManager.manager.gamePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        GameManager.manager.gamePaused = false;
    }
}
