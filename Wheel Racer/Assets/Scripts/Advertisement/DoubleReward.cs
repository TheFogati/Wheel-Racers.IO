using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DoubleReward : MonoBehaviour
{
    public AdsManager ads;
    [Space]
    public Button btn;

    public void DoubleTheReward()
    {
        if (ads.rewardedAdLoaded)
            ads.ShowRewardedAd(DoubleRewardSuccess);
    }
    void DoubleRewardSuccess()
    {
        GameManager.manager.money += AddMoney.totalMoney;
        AddMoney.totalMoney *= 2;
        btn.interactable = false;
        SaveSystem.SaveGame();

        Debug.Log("Reward: Doubled Coins");
    }
}
