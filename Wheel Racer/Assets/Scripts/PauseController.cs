using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PauseController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseScreen;

    public void Pause()
    {
        audioMixer.SetFloat("EngineVolume", -80);
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        GameManager.manager.gamePaused = true;
    }

    public void Resume()
    {
        audioMixer.SetFloat("EngineVolume", 0);
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        GameManager.manager.gamePaused = false;
    }
}
