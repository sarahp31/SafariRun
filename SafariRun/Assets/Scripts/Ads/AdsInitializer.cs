using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidID;
    [SerializeField] string iosID;
    [SerializeField] bool testMode = true;
    private string gameID;

    [SerializeField] RewardedAdsButton rewardedAdsButton;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
    #if UNITY_IOS
            gameID = iosID;
    #elif UNITY_ANDROID
            gameID = androidID;
    #elif UNITY_EDITOR
            gameID = androidID; //Only for testing the functionality in the Editor
    #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID, testMode, this);
        }
    }

 
    public void OnInitializationComplete()
    {
        // Load Rewarded Ad
        rewardedAdsButton.LoadAd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Failed to Initialize");
    }
}