using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompleteMoney : MonoBehaviour
{
    public GameObject notEnough;
    public BuyingScript buy;

    Action<bool> giveReward;

    public void ClosePopup()
    {
        notEnough.SetActive(false);
    }

    public void Complete()
    {
        SayKit.showRewarded(giveReward);

        giveReward = CompleteSuccess;
    }

    void CompleteSuccess(bool give)
    {
        if(give)
        {
            GameManager.manager.money = 300;
            buy.Buy();
        }

        notEnough.SetActive(false);
    }
}
