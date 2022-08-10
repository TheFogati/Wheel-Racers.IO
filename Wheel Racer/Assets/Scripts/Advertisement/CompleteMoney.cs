using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompleteMoney : MonoBehaviour
{
    public GameObject notEnough;
    public BuyingScript buy;

    private void Awake()
    {
        SayKit.isRewardedAvailable();
    }

    public void ClosePopup()
    {
        notEnough.SetActive(false);
    }

    public void Complete()
    {
        SayKit.showRewarded(CompleteSuccess);
    }

    void CompleteSuccess(bool give)
    {
        if(give)
        {
            GameManager.manager.money = 300;
            buy.Buy();

            Debug.Log("Reward: Missing Money");
        }

        notEnough.SetActive(false);
    }
}
