using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleReward : MonoBehaviour
{
    public void DoubleTheReward()
    {
        AdsManager.manager.PlayRewardedAd(DoubleRewardSuccess);
    }
    void DoubleRewardSuccess()
    {
        GameManager.manager.money += AddMoney.totalMoney;
        AddMoney.totalMoney *= 2;
        SaveSystem.SaveGame();
    }
    public void DoubleRewardOnce(Button btn)
    {
        btn.interactable = false;
    }
}
