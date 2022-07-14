using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddMoney : MonoBehaviour
{
    int scoreMoney = 0;
    int positionMoney = 0;
    public static int totalMoney = 0;

    public Text scoreMoneyText;
    public Text positionMoneyText;
    public Text totalMoneyText;
    public TextMeshProUGUI position;
    public EpicUnlocker unlocker;

    void Start()
    {
        scoreMoney = Points.numbers;
        
        switch(PositionOrder.playerPosition)
        {
            case 1:
                positionMoney = 50;
                GameManager.manager.epicUnlockProgress += 15;
                //position.color = new Color32(255, 235, 98, 255);
                break;
            case 2:
                positionMoney = 25;
                GameManager.manager.epicUnlockProgress += 10;
                //position.color = new Color32(173, 173, 173, 255);
                break;
            case 3:
                positionMoney = 12;
                GameManager.manager.epicUnlockProgress += 5;
                //position.color = new Color32(207, 104, 72, 255);
                break;
        }

        totalMoney = scoreMoney + positionMoney;
        GameManager.manager.money += totalMoney;


        print(unlocker.wheelAvailable + " " + unlocker.trailAvailable);
        if (!unlocker.wheelAvailable && !unlocker.trailAvailable)
            GameManager.manager.epicUnlockProgress = 0;
            
        SaveSystem.SaveGame();
    }

    void Update()
    {
        positionMoneyText.text = "Rank Coins: " + positionMoney.ToString();
        scoreMoneyText.text = "Collected Coins: " + scoreMoney.ToString();
        totalMoneyText.text = "Total: " + totalMoney.ToString();
        position.text = PositionOrder.playerPosition.ToString() + "°";
    }
}
