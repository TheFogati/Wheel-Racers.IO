using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoney : MonoBehaviour
{
    int scoreMoney = 0;
    int positionMoney = 0;
    public static int totalMoney = 0;

    public Text scoreMoneyText;
    public Text positionMoneyText;
    public Text totalMoneyText;

    void Start()
    {
        scoreMoney = Points.numbers;
        
        switch(PositionOrder.playerPosition)
        {
            case 1:
                positionMoney = 50;
                GameManager.manager.epicUnlockProgress += 15;
                break;
            case 2:
                positionMoney = 25;
                GameManager.manager.epicUnlockProgress += 10;
                break;
            case 3:
                positionMoney = 12;
                GameManager.manager.epicUnlockProgress += 5;
                break;
        }

        totalMoney = scoreMoney + positionMoney;
        GameManager.manager.money += totalMoney;

        if (!EpicUnlocker.wheelAvailable && !EpicUnlocker.trailAvailable)
            GameManager.manager.epicUnlockProgress = 0;
            
        SaveSystem.SaveGame();
    }

    void Update()
    {
        scoreMoneyText.text = scoreMoney.ToString();
        positionMoneyText.text = positionMoney.ToString();
        totalMoneyText.text = totalMoney.ToString();
    }
}
