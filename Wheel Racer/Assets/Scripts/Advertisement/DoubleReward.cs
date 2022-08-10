using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DoubleReward : MonoBehaviour
{
    public Button btn;

    public void DoubleTheReward()
    {
        SayKit.showRewarded(DoubleRewardSuccess);
    }
    void DoubleRewardSuccess(bool give)
    {
        if(give)
        {
            GameManager.manager.money += AddMoney.totalMoney;
            AddMoney.totalMoney *= 2;
            btn.interactable = false;
            SaveSystem.SaveGame();

            Debug.Log("Reward: Doubled Coins");
        }
    }
}
