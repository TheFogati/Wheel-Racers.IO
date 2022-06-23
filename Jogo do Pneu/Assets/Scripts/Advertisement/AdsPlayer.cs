using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsPlayer : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if(GameManager.manager.runs >= 4)
        {
            InterstitialAdAfterRuns();
        }
    }

    #region Interstitial Ads Placement
    void InterstitialAdAfterRuns()
    {
        GameManager.manager.runs = 0;
        StartCoroutine(AdTimer());
    }

    IEnumerator AdTimer()
    {
        yield return new WaitForSeconds(.3f);
        AdsManager.manager.PlayInterstitialAd();
    }
    #endregion

    #region Double the Reward
    public void DoubleReward()
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
    #endregion
}
