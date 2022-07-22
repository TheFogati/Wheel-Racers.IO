using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnlockEpic : MonoBehaviour
{
    Action<bool> giveReward;

    public GameObject unlockedBox;
    [Space]
    public Image unlockedImage;
    public Text unlockedText;
    [Space]
    public Sprite[] epicWheels;
    public Sprite[] epicTrails;
    Sprite unlockedSprite;

    public void Unlock()
    {
        SayKit.showRewarded(giveReward);

        giveReward = UnlockIt;
    }

    void UnlockIt(bool give)
    {
        if(give)
        {
            if (GameManager.manager.unlockWheel)
                CheckWheel();
            else
                CheckTrail();

            GameManager.manager.unlockWheel = !GameManager.manager.unlockWheel;
            GameManager.manager.epicUnlockProgress = 0;
            unlockedBox.SetActive(true);
            unlockedImage.sprite = unlockedSprite;

            SaveSystem.SaveGame();
        }
    }


    void CheckWheel()
    {
        int rnd = UnityEngine.Random.Range(0, GameManager.manager.epicWheels.Length);

        if (GameManager.manager.epicWheels[rnd].isUnlocked)
            CheckWheel();
        else
        {
            GameManager.manager.epicWheels[rnd].isUnlocked = true;
            unlockedSprite = epicWheels[rnd];
            unlockedText.text = "Epic Wheel Unlocked";
        }
            
    }

    void CheckTrail()
    {
        int rnd = UnityEngine.Random.Range(0, GameManager.manager.epicTrails.Length);

        if (GameManager.manager.epicTrails[rnd].isUnlocked)
            CheckTrail();
        else
        {
            GameManager.manager.epicTrails[rnd].isUnlocked = true;
            unlockedSprite = epicTrails[rnd];
            unlockedText.text = "Epic Trail Unlocked";
        }
            
    }


    public void CloseBox(GameObject box)
    {
        box.SetActive(false);
    }
}
