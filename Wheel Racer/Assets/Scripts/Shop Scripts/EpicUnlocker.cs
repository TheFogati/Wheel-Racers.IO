using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpicUnlocker : MonoBehaviour
{
    public GameObject progression;
    public Text progressionText;
    public Slider progressionBar;
    public Text progressionPercent;
    [Space]
    public GameObject unlockBtn;
    public Text unlockText;
    [Space]
    public GameObject unavailability;

    bool wheelAvailable;
    bool trailAvailable;

    void Start()
    {
        wheelAvailable = false;
        trailAvailable = false;
    }

    void Update()
    {
        CheckAvailableEpics();

        if(wheelAvailable || trailAvailable)
        {
            if (GameManager.manager.epicUnlockProgress < 100)
            {
                progression.SetActive(true);
                unlockBtn.SetActive(false);
                unavailability.SetActive(false);
                TrackProgress();
            }
            else
            {
                progression.SetActive(false);
                unlockBtn.SetActive(true);
                unavailability.SetActive(false);

                if (GameManager.manager.unlockWheel)
                    unlockText.text = "Unlock new Epic Wheel";
                else
                    unlockText.text = "Unlock new Epic Trail";
            }
        }
        else
        {
            progression.SetActive(false);
            unlockBtn.SetActive(false);
            unavailability.SetActive(true);
        }

        progressionPercent.text = progressionBar.value.ToString() + "%";
    }

    void CheckAvailableEpics()
    {
        foreach(EpicWheels w in GameManager.manager.epicWheels)
        {
            if (!w.isUnlocked)
            {
                wheelAvailable = true;
                break;
            }
            else
                wheelAvailable = false;
                
        }
        foreach(EpicTrails t in GameManager.manager.epicTrails)
        {
            if (!t.isUnlocked)
            {
                trailAvailable = true;
                break;
            }
            else
                trailAvailable = false;
                
        }
    }

    void TrackProgress()
    {
        if (GameManager.manager.unlockWheel)
        {
            if (wheelAvailable)
            {
                progressionBar.value = GameManager.manager.epicUnlockProgress;
                progressionText.text = "Progress to unlock new Epic Wheel";
            }
            else
                GameManager.manager.unlockWheel = false;
        }
        else
        {
            if (trailAvailable)
            {
                progressionBar.value = GameManager.manager.epicUnlockProgress;
                progressionText.text = "Progress to unlock new Epic Trail";
            }
            else
                GameManager.manager.unlockWheel = true;
        }
    }

}
