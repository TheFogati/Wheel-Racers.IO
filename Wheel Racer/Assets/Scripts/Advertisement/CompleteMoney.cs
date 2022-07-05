using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMoney : MonoBehaviour
{
    public GameObject notEnough;
    public BuyingScript buy;

    public void ClosePopup()
    {
        notEnough.SetActive(false);
    }

    public void Complete()
    {
        AdsManager.manager.PlayRewardedAd(CompleteSuccess);
    }

    void CompleteSuccess()
    {
        GameManager.manager.money = 300;
        buy.Buy();
        notEnough.SetActive(false);
    }
}
