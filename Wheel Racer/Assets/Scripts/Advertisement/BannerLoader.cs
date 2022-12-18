using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerLoader : MonoBehaviour
{
    public AdsManager ads;
    [Space]
    public bool showBanner;

    void Update()
    {
        if(showBanner)
            ads.ShowBanner();
        else
            ads.HideBanner();
    }
}
