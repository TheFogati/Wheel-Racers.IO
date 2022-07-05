using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockEpic : MonoBehaviour
{
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
        AdsManager.manager.PlayRewardedAd(UnlockIt);
    }

    void UnlockIt()
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


    void CheckWheel()
    {
        int rnd = Random.Range(0, GameManager.manager.epicWheels.Length);

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
        int rnd = Random.Range(0, GameManager.manager.epicTrails.Length);

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
