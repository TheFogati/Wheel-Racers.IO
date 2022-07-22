using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DoubleReward : MonoBehaviour
{
    Action<bool> giveReward;

    public Button btn;

    public void DoubleTheReward()
    {
        SayKit.showRewarded(giveReward);

        giveReward = DoubleRewardSuccess;
    }
    void DoubleRewardSuccess(bool give)
    {
        if(give)
        {
            GameManager.manager.money += AddMoney.totalMoney;
            AddMoney.totalMoney *= 2;
            btn.interactable = false;
            SaveSystem.SaveGame();
        }
    }
}
