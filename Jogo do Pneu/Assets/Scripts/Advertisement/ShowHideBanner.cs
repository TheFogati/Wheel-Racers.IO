using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideBanner : MonoBehaviour
{
    public bool hide;

    void Start()
    {
        if (hide)
            AdsManager.manager.HideAdBanner();
        else
            AdsManager.manager.ShowAdBanner();
    }
}
