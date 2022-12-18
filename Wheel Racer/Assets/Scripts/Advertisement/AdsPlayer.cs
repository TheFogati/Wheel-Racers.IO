using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsPlayer : MonoBehaviour
{
    public AdsManager ads;
    bool adAvailability;


    void Update()
    {
        if (!ads.rewardedAdLoaded)
            ads.LoadRewardedAd();
        if (!ads.interstitialAdLoaded)
            ads.LoadInterstitialAd();

        if (GameManager.manager.runs >= 2 && ads.interstitialAdLoaded)
        {
            ads.ShowInterstitialAd();
            GameManager.manager.runs = 0;
            Debug.Log("Sponsor Time");
        }
    }
}
