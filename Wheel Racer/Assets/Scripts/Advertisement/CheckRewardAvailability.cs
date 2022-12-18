using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRewardAvailability : MonoBehaviour
{
    public AdsManager ads;
    [Space]
    Button btn;
    Text txt;

    string originalTxt;

    void Start()
    {
        btn = GetComponent<Button>();
        txt = GetComponentInChildren<Text>();

        if (txt != null)
            originalTxt = txt.text;
    }

    void Update()
    {
        if(ads.rewardedAdLoaded)
        {
            if (txt != null)
                txt.text = originalTxt;
            btn.interactable = true;
        }
        else
        {
            if (txt != null)
                txt.text = "Unavailable";
            btn.interactable = false;
        }
    }
}
