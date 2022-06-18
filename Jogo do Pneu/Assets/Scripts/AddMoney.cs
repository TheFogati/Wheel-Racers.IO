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
        scoreMoney = Points.numbers/10;
        
        switch(PositionOrder.playerPosition)
        {
            case 1:
                positionMoney = 100;
                break;
            case 2:
                positionMoney = 50;
                break;
            case 3:
                positionMoney = 25;
                break;
        }

        totalMoney = scoreMoney + positionMoney;
        GameManager.manager.money += totalMoney;

        SaveSystem.SaveGame();
    }

    void Update()
    {
        scoreMoneyText.text = scoreMoney.ToString();
        positionMoneyText.text = positionMoney.ToString();
        totalMoneyText.text = totalMoney.ToString();
    }
}
