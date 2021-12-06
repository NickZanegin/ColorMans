using System;
using UnityEngine;

public class AppLovinInitialized : MonoBehaviour
{
    string adUnitId = "d865be157dca220c";
    int retryAttempt;
    bool AdsPlaying = false;
    bool click = false;
    bool newAds;

    public event Action addClose;
    public event Action Initialize;
    public event Action addFaill;
    public void Awake()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // AppLovin SDK is initialized, start loading ads
        };

        MaxSdk.SetSdkKey("CgG1BtqwUb8gNyhBVM-6AoTTU-yyGD9UyFS4QZzB7qdKR94hTICWTvRbNbGfmkw9VEQ8cUSDZFXLFELip15EZB");
        MaxSdk.SetUserId("USER_ID");
        //MaxSdk.SetIsAgeRestrictedUser(true);
        MaxSdk.InitializeSdk();
        //InitializeInterstitialAds();
    }
    public void InitializeInterstitialAds()
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
        // Load the first interstitial
        LoadInterstitial();
    }

    public void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(adUnitId);
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'
        Initialize?.Invoke();
        // Reset retry attempt
        retryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)
        addFaill?.Invoke();
        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

        Invoke("LoadInterstitial", (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) 
    {
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        LoadInterstitial();
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) 
    {
        if (newAds)
        {
            click = true;
            AdsPlaying = false;
            newAds = false;
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        addClose?.Invoke();
        if (!click)
        {
        }
        AdsPlaying = false;
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
    }

    public void ShowAds()
    {
        newAds = true;
        if (MaxSdk.IsInterstitialReady(adUnitId))
        {
            AdsPlaying = true;
            MaxSdk.ShowInterstitial(adUnitId);
        }
    }
    private void OnApplicationQuit()
    {
        if (AdsPlaying)
        {
        }
    }
}
