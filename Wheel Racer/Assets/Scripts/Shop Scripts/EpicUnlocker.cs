using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EpicUnlocker : MonoBehaviour
{
    public Animator anim;
    [Space]
    public TextMeshProUGUI newThingsText;
    public Text progressionText;
    public Slider progressionBar;
    public Button progressButton;

    public bool wheelAvailable;
    public bool trailAvailable;

    private void Awake()
    {
        CheckAvailableEpics();
    }

    void Update()
    {
        

        if (wheelAvailable || trailAvailable)
        {
            if(GameManager.manager.epicUnlockProgress < 100)
            {
                anim.SetInteger("Unlocks", 0);
                progressionBar.gameObject.SetActive(true);
                progressButton.gameObject.SetActive(false);
            }
            else
            {
                anim.SetInteger("Unlocks", 1);
                progressionBar.gameObject.SetActive(false);
                progressButton.gameObject.SetActive(true);
            }
        }
        else
        {
            anim.SetInteger("Unlocks", 2);
        }

        if(GameManager.manager.unlockWheel)
            newThingsText.text = "An Epic Wheel";
        else
            newThingsText.text = "An Epic Trail";

        progressionBar.value = GameManager.manager.epicUnlockProgress;
        progressionText.text = GameManager.manager.epicUnlockProgress.ToString() + "%";
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
}
