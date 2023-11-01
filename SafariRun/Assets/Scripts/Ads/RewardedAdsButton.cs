using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
 
public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button AdButton;
    [SerializeField] string androidrewardedID = "Rewarded_Android";
    [SerializeField] string iosrewardedID = "Rewarded_iOS";
    string adUnitId = null; 
 
    void Awake() {   
#if UNITY_IOS
        adUnitId = iosrewardedID;
#elif UNITY_ANDROID
        adUnitId = androidrewardedID;
#endif
        AdButton.interactable = false;
    }
 
    public void LoadAd() {
        Advertisement.Load(adUnitId, this);
    }
 
    public void OnUnityAdsAdLoaded(string adUnitId) {
        if (adUnitId.Equals(adUnitId)) {
            AdButton.onClick.AddListener(ShowAd);
            AdButton.interactable = true;
        }
    }
 
    public void ShowAd() {
        AdButton.interactable = false;
        Advertisement.Show(adUnitId, this);
    }
 
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) {
        if (adUnitId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) {
            // Give out coins
            Debug.Log("Earn 10 coins");

            AdButton.interactable = true;
        }
    }
 
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message) {
        Debug.Log("Failed to Load");
    }
 
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message) {
        Debug.Log("Filed to show");
    }
 
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
 
    void OnDestroy() {
        AdButton.onClick.RemoveAllListeners();
    }
}