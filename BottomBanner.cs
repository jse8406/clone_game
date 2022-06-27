using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; //애드몹

public class BottomBanner : MonoBehaviour
{
    // Start is called before the first frame update
     private BannerView bannerView;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5580044434392562/7277947886";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        AdSize adSize = new AdSize(200, 250);
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomRight);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
