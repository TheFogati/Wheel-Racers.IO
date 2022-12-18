using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompleteMoney : MonoBehaviour
{
    public AdsManager ads;
    [Space]
    public GameObject notEnough;
    public BuyingScript buy;

    public void ClosePopup()
    {
        notEnough.SetActive(false);
    }

    public void CheckAvailability()
    {
        ads.LoadRewardedAd();
    }
    public void Complete()
    {
        if (ads.rewardedAdLoaded)
            ads.ShowRewardedAd(CompleteSuccess);
    }

    void CompleteSuccess()
    {
        GameManager.manager.money = 300;
        buy.Buy();

        Debug.Log("Reward: Missing Money");

        notEnough.SetActive(false);
    }
}
