using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
#if UNITY_ANDROID
    string gameId = "4788565";
#else
    string gameId = "4788564";
#endif

    Action onRewardedAdSuccess;
    public bool rewardedAdLoaded;
    public bool interstitialAdLoaded;

    void Start()
    {
        Advertisement.Initialize(gameId, true, this);
    }

    public void LoadInterstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }
    public void ShowInterstitialAd()
    {
        Advertisement.Show("Interstitial_Android", this);
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load("Rewarded_Android", this); 
    }
    public void ShowRewardedAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;

        Advertisement.Show("Rewarded_Android", this);
    }

    public void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load("Banner_Android", new BannerLoadOptions {loadCallback = OnBannerLoaded, errorCallback = OnBannerError});
    }
    void OnBannerLoaded()
    {
        Advertisement.Banner.Show("Banner_Android");
    }
    void OnBannerError(string message)
    {

    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }




    #region Listeners
    //-----Initialization-----
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Failed Initializing: {error.ToString()} - {message}");
    }
    //------------------------
    //-----Load-----
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ads Loaded");
        if (placementId == "Rewarded_Android")
            rewardedAdLoaded = true;
        else if (placementId == "Interstitial_Android")
            interstitialAdLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit: {placementId}: {error.ToString()} - {message}");
        if (placementId == "Rewarded_Android")
            rewardedAdLoaded = false;
        else if (placementId == "Interstitial_Android")
            interstitialAdLoaded = false;
    }
    //--------------
    //-----Show-----
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ads Show Failed");
    }
    
    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ads Show Started");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ads Show Clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Show Completed For" + placementId);
        if(placementId == "Rewarded_Android")
        {
            onRewardedAdSuccess.Invoke();
            print("Entered");
            rewardedAdLoaded = false;
        }
        else if(placementId == "Interstitial_Android")
        {
            interstitialAdLoaded = false;
        }

        GameManager.manager.runs = 0;
    }
    //--------------
    #endregion
}
