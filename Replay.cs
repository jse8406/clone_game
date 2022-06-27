using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class Replay : MonoBehaviour
{ 
    private InterstitialAd interstitial;
    public Canvas mycanvas;

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5580044434392562/1849073958";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void ReplayGame(){

        RequestInterstitial();

        StartCoroutine(showInterstitial());

        IEnumerator showInterstitial()
        {
            while(!this.interstitial.IsLoaded())
            {
                yield return new WaitForSeconds(0.2f);
            }
            this.interstitial.Show();
            mycanvas.sortingOrder = -1;
        }
    }
    public void HandleOnAdClosed(object sender, System.EventArgs args){
        SceneManager.LoadScene("PlayScene");
    }
}
