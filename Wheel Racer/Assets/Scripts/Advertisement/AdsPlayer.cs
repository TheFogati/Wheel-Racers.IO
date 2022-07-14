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
        if(GameManager.manager.runs >= 2)
            InterstitialAdAfterRuns();
    }

    void InterstitialAdAfterRuns()
    {
        GameManager.manager.runs = 0;
        AdsManager.manager.PlayInterstitialAd();
    }
}
